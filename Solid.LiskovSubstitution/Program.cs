// See https://aka.ms/new-console-template for more information
using Solid.LiskovSubstitution.Good;
//using Solid.LiskovSubstitution.Bad;


//BasePhone phone=new IPhone();
//phone.Call();
//phone.TakePhoto();


//phone = new Nokia3310();
//phone.Call();
//phone.TakePhoto();


BasePhone phone = new IPhone();
phone.Call();

((ITakePhoto)phone).TakePhoto();

phone = new Nokia3310();
phone.Call();
//ITakePhoto burada çağrılamaz

//parent child kendi aralarında yer değiştirdiğinde uygulamada hata olmamalı