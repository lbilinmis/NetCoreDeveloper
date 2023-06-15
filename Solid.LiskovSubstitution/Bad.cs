namespace Solid.LiskovSubstitution.Bad
{
    public abstract class BasePhone
    {
        public void Call()
        {
            Console.WriteLine("Arama yapıldı..");
        }

        public abstract void TakePhoto();
    }


    public class IPhone : BasePhone
    {
        public override void TakePhoto()
        {
            Console.WriteLine("Fotoğraf çekme işlemi yapıldı..");

        }
    }

    public class Nokia3310 : BasePhone
    {
        public override void TakePhoto()
        {
            throw new NotImplementedException();
        }
    }

}
