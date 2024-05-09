using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MaskImageTool
{
    static class MaskImage
    {
        static public void CreateFromMarkColor(string targetFilePath)
        {
            CreateFromMarkColor(targetFilePath, 255, 0, 0);
        }

        static public void CreateFromMarkColor(string targetFilePath,byte mR,byte mG,byte mB)
        {
            Bitmap originalImage = new Bitmap(targetFilePath);
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    if (originalColor.R == mR && originalColor.G == mG && originalColor.B == mB)
                    {
                        newImage.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        newImage.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            string directory = Path.GetDirectoryName(targetFilePath);
            string oldFileName = Path.GetFileName(targetFilePath);
            string newFileName = "_" + oldFileName;
            File.Move(targetFilePath, Path.Combine(directory, newFileName));

            newImage.Save(targetFilePath);

            Bitmap compositeImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    Color newColor = newImage.GetPixel(x, y);

                    int r = (originalColor.R + newColor.R) / 2;
                    int g = (originalColor.G + newColor.G) / 2;
                    int b = (originalColor.B + newColor.B) / 2;

                    compositeImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            compositeImage.Save(Path.Combine(directory, "x" + oldFileName));
        }
    }
}
