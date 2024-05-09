using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace OnnxRuntime_ImageClassification
{
    class OnnxImageClassification
    {
        static public string RunSession(string onnxFilePath, string imageFilePath, bool ImShow = false)
        {
            Mat imgSrc = Cv2.ImRead(imageFilePath, ImreadModes.Color);

            int inputWidth = imgSrc.Width;
            int inputHeight = imgSrc.Height;
            string dstString = RunSessionAndDrawMat(onnxFilePath, imgSrc, ImShow);
            imgSrc.Dispose();

            return dstString;
        }

        static public string RunSessionAndDrawMat(string onnxFilePath, Mat imgSrc, bool ImShow = false)
        {
            using (var session = new InferenceSession(onnxFilePath))
            {
                return RunSessionAndDrawMat(session, imgSrc, ImShow);
            }
        }

        static public string RunSessionAndDrawMat(InferenceSession session, Mat imgSrc,  bool ImShow = false)
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

            using (var results = session.Run(inputs))
            {
                Tensor<float> scores = results[1].AsTensor<float>();

                // Process results
                int indicesLength = (int)scores.Length;
                for (int i = 0; i < indicesLength; i++)
                {
                    var score = scores[0];
                    LineOutput.Add(score.ToString("g4"));
                }


                Tensor<float> segmentationImage = results[0].AsTensor<float>();

                // Tensorの次元を取得（高さ、幅）
                int height = 224;
                int width = 224;

                // 新しいMatを作成
                Mat grayscaleImage = new Mat(height, width, MatType.CV_8UC1);

                // Tensorの各要素を走査
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                            // Tensorからピクセル値を取得
                            float pixelValue = segmentationImage[0,0,0,y*width + x];

                            // ピクセル値を0-255の範囲にスケーリング
                            byte grayScale = (byte)(pixelValue * 2);

                            // Matに新しいピクセル値を設定
                            grayscaleImage.Set(y, x, grayScale);

                    }
                }

                // Matを保存
                Cv2.ImWrite(@"R:\result\grayscaleImage.png", grayscaleImage);
            }

            return string.Join("\t", LineOutput.Take(3).ToArray());
        }

        static private DenseTensor<float> getDenseTensorFromMat(Mat src, int tensorWidth, int tensorHeight)
        {
            var dstTensor = new DenseTensor<float>(new[] { 1, 3, tensorWidth, tensorHeight });

            Size newSize = new Size(tensorWidth, tensorHeight);
            Mat dst = new Mat();
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
