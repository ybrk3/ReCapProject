using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba listeye eklendi";
        public static string CarDeleted = "Araç silinmiştir";
        public static string CarsListed = "Arabalar Listelendi";
        public static string CarNotFound = "Aranılan araç bulunamadı";
        public static string InvalidCarName = "Araba ismi en az 2 karakter olmalı";
        public static string MaintenanceTime = "Sistem bakımda. Lütfen daha sonra deneyiniz";
        public static string CarUpdated = "Araç bilgileri güncellenmiştir";
        public static string UserNotAdded = "Email ve Password bilgileri boş kalamaz";
        public static string UserAdded = "Hoşgeldiniz";
        public static string UserDeleted = "Hesabınız başarıyla kapatılmıştır";
        public static string SuccessfullRent = "Araçınızı teslim alabilirsiniz";
        public static string UnsuccessfullRent = "Araç müsait değil";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandUpdated = "Marka bilgisi güncellendi";
        public static string ImageUploaded = "Resim başarıyla yüklendi";
        public static string ImageDeleted = "Resim başarıyla silinmiştir";
        public static string CarImageCountExceeded = "5'den fazla resim yükleyemezsiniz";
        public static string InvalidImageExtension = "Dosya tipi .jpeg, .png veya .jpg olmalıdır";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists="Bu email adresine kayıtlı zaten bir kullanıcı var";
        public static string AccessTokenCreated="Token başarıyla oluşturuldu";
        public static string UserRegistered="Kullanıcı başarıyla oluşturuldu";
    }
}
