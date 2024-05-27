using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using OpenCvSharp;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace OnnxRuntime_ImageClassification
{
    class OnnxImageClassification
    {
        static public string RunSession(string onnxFilePath, string imageFilePath, float alpha = 0, float beta = float.NaN, bool ImShow = false)
        {
            Mat imgSrc = Cv2.ImRead(imageFilePath, ImreadModes.Color);

            int inputWidth = imgSrc.Width;
            int inputHeight = imgSrc.Height;
            Bitmap imgMap = new Bitmap(inputWidth, inputHeight);
            string dstString = "";
            (dstString, imgMap) = RunSessionAndDrawMap(onnxFilePath, imgSrc, alpha, beta, ImShow);
            imgSrc.Dispose();
            imgMap.Dispose();
            return dstString;
        }

        static public (string, Bitmap) RunSessionAndDrawMap(string onnxFilePath, string imageFilePath, float alpha = 0, float beta = float.NaN, bool ImShow = false)
        {
            using (Mat imgSrc = new Mat(imageFilePath))
            {
                return RunSessionAndDrawMap(onnxFilePath, imgSrc, alpha, beta, ImShow);
            }
        }

        static public (string, Bitmap) RunSessionAndDrawMap(string onnxFilePath, Mat imgSrc, float alpha = 0, float beta = float.NaN, bool ImShow = false)
        {
            using (var session = new InferenceSession(onnxFilePath))
            {
                return RunSessionAndDrawMap(session, imgSrc, alpha, beta, ImShow);
            }
        }

        static public (string, Bitmap) RunSessionAndDrawMap(InferenceSession session, Mat imgSrc, float alpha = 0, float beta = float.NaN, bool ImShow = false)
        {
            int inputWidth = imgSrc.Width;
            int inputHeight = imgSrc.Height;
            var input = getDenseTensorFromMat(imgSrc, inputWidth, inputHeight);

            var inputShape = new DenseTensor<float>(new[] { 1, 2 });
            inputShape[0, 0] = imgSrc.Height;
            inputShape[0, 1] = imgSrc.Width;

            var inputMeta = session.InputMetadata;
            var inputName = inputMeta.First().Key;
            var inputDims = inputMeta.First().Value.Dimensions;

            var inputs = new NamedOnnxValue[] { NamedOnnxValue.CreateFromTensor(inputName, input) };

            List<string> LineOutput = new List<string>();

            Mat colorMap = new Mat();
            Mat colorMixMap = new Mat();

            using (var results = session.Run(inputs))
            {
                Tensor<float> segmentationImage = results[0].AsTensor<float>();

                int height = imgSrc.Height;
                int width = imgSrc.Width;

                Mat floatMap = new Mat(height, width, MatType.CV_32FC1);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        float pixelValue = segmentationImage[0, 0, 0, y * width + x];
                        floatMap.Set(y, x, pixelValue);
                    }
                }

                double minDouble = 0;
                double maxDouble = 0;

                if (float.IsNaN(beta))
                {
                    floatMap.MinMaxIdx(out minDouble, out maxDouble);
                    beta = (float)minDouble;
                }

                if (alpha == 0)
                {
                    colorMap = floatMap.Normalize(0, 255, NormTypes.MinMax, MatType.CV_8UC1);
                }
                else
                {
                    floatMap.ConvertTo(colorMap, MatType.CV_8UC1, alpha, beta);
                }

                Cv2.ApplyColorMap(colorMap, colorMap, ColormapTypes.Jet);
                Cv2.AddWeighted(imgSrc, 0.5, colorMap, 0.5, 0, colorMixMap);

                colorMap.Dispose();


                Tensor<float> scores = results[1].AsTensor<float>();

                int indicesLength = (int)scores.Length;
                for (int i = 0; i < indicesLength; i++)
                {
                    var score = scores[0];
                    LineOutput.Add(score.ToString("g4") + "\t" + minDouble.ToString("g4") + "\t" + maxDouble.ToString("g4"));
                }

            }
            return (string.Join("\t", LineOutput.Take(3).ToArray()), OpenCvSharp.Extensions.BitmapConverter.ToBitmap(colorMixMap));
        }

        static private DenseTensor<float> getDenseTensorFromMat(Mat src, int tensorWidth, int tensorHeight)
        {
            Mat dst = new Mat();
            var dstTensor = new DenseTensor<float>(new[] { 1, 3, tensorWidth, tensorHeight });
            OpenCvSharp.Size newSize = new OpenCvSharp.Size(tensorWidth, tensorHeight);
            Cv2.Resize(src, dst, newSize);

            for (int y = 0; y < tensorHeight; y++)
            {
                for (int x = 0; x < tensorWidth; x++)
                {
                    Vec3b color = dst.At<Vec3b>(y, x);
                    dstTensor[0, 0, y, x] = ((float)color.Item2) / 255f;
                    dstTensor[0, 1, y, x] = ((float)color.Item1) / 255f;
                    dstTensor[0, 2, y, x] = ((float)color.Item0) / 255f;
                }
            }

            dst.Dispose();
            return dstTensor;
        }
    }
}
