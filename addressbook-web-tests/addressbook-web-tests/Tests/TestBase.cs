using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}

//[TearDown]
//public void TearDownTest()
//{
//    ApplicationManager.GetIntance().Driver.Quit();
//}
// куда девать этот метод
// как понять сколько раз запускается и во сколько потоков
// посмотреть видео в закладках про многопоточность
