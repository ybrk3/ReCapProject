using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager : IFileHelper
    {
        public string Add(IFormFile file, string root) //Dosya ve kayıt edilecek uzantı istenir
        {
            if (file.Length > 0) //Yüklenecek dosyanın varlığı kontrol edilir.
            {
                if (!Directory.Exists(root)) //Dosyaların kaydedileceği yerin kontrolü yapılır
                {
                    Directory.CreateDirectory(root); //Dosyanın kaydedileceği yer yok ise oluşturulur
                }
                string extension = Path.GetExtension(file.FileName); //Yüklenecek dosyanın uzantısı çekilir
                string fileName = Guid.NewGuid().ToString(); //Yüklenecek dosya ismi random olarak çekilir
                string filePath = fileName + extension; //Dosya ismi ve uzantısı birleştirili (.txt, .jpeg vb.)
                using (FileStream fileStream = File.Create(root + filePath)) //Dosyanın yükleneceği yer, dosya ismi ve uzantısı üzerinden ilgili yerde
                                                                             //dosya oluşturulur.
                {

                    file.CopyTo(fileStream);//Kopyalanacak dosyanın kopyalanacağı akışı belirtti.
                                            //yani yukarıda gelen IFromFile türündeki file dosyasınınnereye kopyalacağını söyledik.
                    fileStream.Flush();//arabellekten siler. Dosyayı kapatır.
                    return filePath;//burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
                }
            }
            return null;
        }

        public void Delete(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root) //string ile filePath döndürülüp sql'de tutulacak
        {
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath);
            }
            return Add(file, root);
        }
    }
}
