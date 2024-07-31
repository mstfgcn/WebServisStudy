using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;

namespace WS.Model.Entities
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public string? PicturePath {  get; set; }
        public byte[]? Picture { get; set; }
        public bool? IsActive { get; set; }

        [NotMapped]
        public string Base64Picture
        {
            get
            {
                if (Picture != null)
                {
                    var base64Str = string.Empty;
                    using (var ms = new MemoryStream())
                    {
                        int offSet = CategoryId <= 8 ? 78 : 0;
                        //elimizdeki byte dizisini 78. bitten itibaren Ms e yerleştirdik
                        ms.Write(Picture, offSet, Picture.Length - offSet);
                        //Bitmap kullanmak için System Drawing kütüphanesini ekledik.
                        var bmp = new Bitmap(ms);

                        using (var ms1 = new MemoryStream())
                        {
                            bmp.Save(ms1, ImageFormat.Jpeg);
                            //stream içindeki veriyi byte dizisine çeviricez
                            base64Str = Convert.ToBase64String(ms1.ToArray());
                        }

                    }
                    return base64Str;
                }
                return string.Empty;
            }
        }
        public List<Product>? Products { get; set; }
    }
}
