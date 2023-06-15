namespace Solid.LiskovSubstitution.Good
{
    public abstract class BasePhone
    {
        public void Call()
        {
            Console.WriteLine("Arama yapıldı..");
        }

    }

    public interface ITakePhoto
    {
        void TakePhoto();
    }

    public class IPhone : BasePhone, ITakePhoto
    {
        public void TakePhoto()
        {
            Console.WriteLine("Fotoğraf çekme işlemi yapıldı..");
        }
    }

    public class Nokia3310 : BasePhone
    {

    }
}
