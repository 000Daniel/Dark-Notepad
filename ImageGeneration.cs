using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    internal class ImageGeneration
    {
        bool failedToGenerate = false;
                //  'GenerateImage()' uses a texture composited from black and white pixels.
                //  The darker the pixels are the more 'c2' would override 'c1'.
                //  This is used for custom icons when the user changes themes.
                //  It then saves the BitMap image to a .png file in a 'temp' folder.
        public string GenerateImage(Bitmap mask,Color c1, Color c2, string name)
        {
            try
            {
                Rectangle rect = new Rectangle(0, 0, mask.Width, mask.Height);
                Bitmap bm = new Bitmap(rect.Width, rect.Height);
                Graphics g = Graphics.FromImage(bm);

                Brush b = new SolidBrush(c1);
                g.FillRectangle(b, rect);

                for (int i = 0; i < bm.Width; i++)
                    for (int j = 0; j < bm.Height; j++)
                    {
                        Color mask_c = mask.GetPixel(i, j);
                        int alpha_Value = (mask_c.R + mask_c.G + mask_c.B) / 3;

                        float mask_Value = 0f;
                        if (alpha_Value == 0)
                        {
                            mask_Value = 0f;
                        }
                        else
                        {
                            mask_Value = (float)alpha_Value / (float)255;
                        }

                        Color new_c = Color.FromArgb(
                            (int)(c1.R * mask_Value + c2.R * (1 - mask_Value)),
                            (int)(c1.G * mask_Value + c2.G * (1 - mask_Value)),
                            (int)(c1.B * mask_Value + c2.B * (1 - mask_Value)));
                        bm.SetPixel(i, j, new_c);
                    }

                string temp_folder_path = Path.Combine(Environment.GetEnvironmentVariable("TEMP"),"DarkNotepad-000Daniel-temp");
                if (!Directory.Exists(temp_folder_path))
                {
                    Directory.CreateDirectory(temp_folder_path);
                }
                string image_path = Path.Combine(temp_folder_path, name + ".png");
                bm.Save(@image_path, System.Drawing.Imaging.ImageFormat.Png);
                bm.Dispose();
                return image_path;
            }
            catch
            {
                failedToGenerate = true;
                return null;
            }
        }

                //  This 'LoadImage()' loads the generated images by name.
        public Bitmap LoadImage(string name)
        {
            try
            {
                string temp_folder_path = Path.Combine(Environment.GetEnvironmentVariable("TEMP"),"DarkNotepad-000Daniel-temp");

                if (!Directory.Exists(temp_folder_path) || !File.Exists(Path.Combine(temp_folder_path, name + ".png")))
                {
                    if (failedToGenerate)
                    {
                        return Resource1.Missing_Image;
                    }

                    Application.OpenForms.OfType<Notepad>().First().CreateCustomIcons();
                }

                string image_path = Path.Combine(temp_folder_path, name + ".png");
                var bitmap_ms = new MemoryStream(File.ReadAllBytes(image_path));
                Bitmap loaded_bitmap = (Bitmap)Bitmap.FromStream(bitmap_ms);
                bitmap_ms.Dispose();
                return loaded_bitmap;
            }
            catch
            {
                return Resource1.Missing_Image;
            }
        }
    }
}
