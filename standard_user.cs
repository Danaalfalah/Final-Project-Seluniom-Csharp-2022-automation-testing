using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace FinalProjectSeluniom
{
    [TestClass]
    public class standard_user
    {
        [TestMethod]
        public void SortHiLo()
        {
            //TestSetup.NavigateToURL(TestSetup.driver,"https://www.saucedemo.com/");
            ////after open web page  use sleep thread
            //System.Threading.Thread.Sleep(18000);

            //you should write the code for login step 

            loginInfo("standard_user", "secret_sauce");
            //Excel excel = new Excel();
            ////excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents - Quality_Assurance__Bayan_Alhassoun_.xlsx", 3);
            ////open excel and send path and number of sheet 
            //excel.OpenExcel(@"C:\Users\DANA\OneDrive\Documents\login_user.xlsx", 1);
            //Random rnd = new Random();
            //int row = rnd.Next(2, 3); // 7

            //loginInfo(excel.ReadExcel(1,row),excel.ReadExcel(2,row));



            //

            //in this step i retuern just one element  (using find elements) because in xpath all elements have unique value

            IWebElement element = TestSetup.driver.FindElement(By.XPath("//div/span/select[@class='product_sort_container']"));
            TestSetup.HighlightElement(TestSetup.driver, element);
            element.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement element1 = TestSetup.driver.FindElement(By.XPath("//div/span/select/option[@value='hilo']"));
            TestSetup.HighlightElement(TestSetup.driver, element1);
            element1.Click();
            System.Threading.Thread.Sleep(5000);


            // in this step i  return collect of inner text (list/array) because all cards have same xpath (in backend have one code in foreach)
            ReadOnlyCollection<IWebElement> webElements = TestSetup.driver.FindElements(By.XPath("//div/div[@class='inventory_item_price']"));

            //creat list to store value & casting value from string to double(in foreach i will casting it )
            double[] prices = new double[webElements.Count];

            for(int i = 0; i < webElements.Count; i++)
            {
                //to return all value(innertext) in xpath for all elements
                //.trim use to remove char from string (here use to remove $ and white space)
               prices[i] =Convert.ToDouble(webElements[i].GetAttribute("innerText").Trim('$',' '));  //return value as a string using convert.toDouble its casting to double

            }

            for(int i=0; i < prices.Length; i++)
            {
                if (i == prices.Length-1)
                {
                    Console.WriteLine("Passed");
                    break;
                }
                
            if (prices[i] >= prices[i + 1] )
                {
                  
                    continue;
                }
                else
                {
                    Console.WriteLine("Faild");//this result should show it in excel sheet  
                    break;
                }
            }



            Logout();


        }



        public static void  loginInfo(string username, string password)
        {
            TestSetup.NavigateToURL(TestSetup.driver, "https://www.saucedemo.com/");
            //after open web page  use sleep thread
            System.Threading.Thread.Sleep(5000);


            IWebElement usernameInput = TestSetup.driver.FindElement(By.XPath("//div//form//input[@id='user-name']"));
            TestSetup.HighlightElement(TestSetup.driver, usernameInput);
            usernameInput.SendKeys(username);
            System.Threading.Thread.Sleep(1000);
            System.Threading.Thread.Sleep(1000);

            IWebElement passInput = TestSetup.driver.FindElement(By.XPath("//div//form//input[@id='password']"));
            TestSetup.HighlightElement(TestSetup.driver, passInput);
            passInput.SendKeys(password);
            System.Threading.Thread.Sleep(1000); System.Threading.Thread.Sleep(1000);

            IWebElement loginBtn = TestSetup.driver.FindElement(By.XPath("//div//form//input[@id='login-button']"));
            TestSetup.HighlightElement(TestSetup.driver, loginBtn);
            loginBtn.Click();
            System.Threading.Thread.Sleep(1000);



        }



        public static void Logout()
        {
            IWebElement sideBar = TestSetup.driver.FindElement(By.XPath("//div//div//button[@id='react-burger-menu-btn']"));
            TestSetup.HighlightElement(TestSetup.driver, sideBar);
            sideBar.Click();
            System.Threading.Thread.Sleep(2000);


            //IWebElement reset = TestSetup.driver.FindElement(By.XPath("//div//div//a[@id='reset_sidebar_link']"));
            //TestSetup.HighlightElement(TestSetup.driver, reset);
            //reset.Click();
            //System.Threading.Thread.Sleep(5000);


            IWebElement logoutBtn = TestSetup.driver.FindElement(By.XPath("//div//div//a[@id='logout_sidebar_link']"));
            TestSetup.HighlightElement(TestSetup.driver, logoutBtn);
            logoutBtn.Click();
            System.Threading.Thread.Sleep(5000);


            TestSetup.driver.Close();
        }




        [TestMethod]
        public void SortLoHi()
        {
            loginInfo("standard_user", "secret_sauce");




            //in this step i retuern just one element  (using find elements) because in xpath all elements have unique value

            IWebElement element = TestSetup.driver.FindElement(By.XPath("//div/span/select[@class='product_sort_container']"));
            TestSetup.HighlightElement(TestSetup.driver, element);
            element.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement element1 = TestSetup.driver.FindElement(By.XPath("//div/span/select/option[@value='lohi']"));
            TestSetup.HighlightElement(TestSetup.driver, element1);
            element1.Click();
            System.Threading.Thread.Sleep(5000);


            // in this step i  return collect of inner text (list/array) because all cards have same xpath (in backend have one code in foreach)
            ReadOnlyCollection<IWebElement> webElements = TestSetup.driver.FindElements(By.XPath("//div/div[@class='inventory_item_price']"));

            //creat list to store value & casting value from string to double(in foreach i will casting it )
            double[] prices = new double[webElements.Count];

            for (int i = 0; i < webElements.Count; i++)
            {
                //to return all value(innertext) in xpath for all elements
                //.trim use to remove char from string (here use to remove $ and white space)
                prices[i] = Convert.ToDouble(webElements[i].GetAttribute("innerText").Trim('$', ' '));  //return value as a string using convert.toDouble its casting to double

            }

            for (int i = 0; i < prices.Length; i++)
            {
                if (i == prices.Length-1 )
                {
                    Console.WriteLine("Passed");
                    break;
                }
                if (prices[i] <= prices[i + 1] )
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Faild");//this result should show it in excel sheet  
                    break;
                }
            }


            Logout();

        }



        [TestMethod]
        public void SortAtoZ()
        {
            loginInfo("standard_user", "secret_sauce");
            //in this step i retuern just one element  (using find elements) because in xpath all elements have unique value

            IWebElement element = TestSetup.driver.FindElement(By.XPath("//div/span/select[@class='product_sort_container']"));
            TestSetup.HighlightElement(TestSetup.driver, element);
            element.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement element1 = TestSetup.driver.FindElement(By.XPath("//div/span/select/option[@value='az']"));
            TestSetup.HighlightElement(TestSetup.driver, element1);
            element1.Click();
            System.Threading.Thread.Sleep(5000);


            // in this step i  return collect of inner text (list/array) because all cards have same xpath (in backend have one code in foreach)
            ReadOnlyCollection<IWebElement> webElements = TestSetup.driver.FindElements(By.XPath("//div//div//div[@class='inventory_item_name']"));

            //creat list to store value & casting value from string to double(in foreach i will casting it )
            string[] prices = new string[webElements.Count];

            for (int i = 0; i < webElements.Count; i++)
            {
                //to return all value(innertext) in xpath for all elements
                //.trim use to remove char from string (here use to remove $ and white space)
                prices[i] = Convert.ToString(webElements[i].GetAttribute("innerText").Trim('$', ' '));  //return value as a string using convert.toDouble its casting to double

            }
            for (int i = 0; i < prices.Length; i++)
            {
                if (i == prices.Length - 1)
                {
                    Console.WriteLine("Passed");
                    break;
                }
                if (prices[i] == prices[i])
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Faild");//this result should show it in excel sheet  
                    break;
                }
            }


            Logout();


        }


        [TestMethod]
        public void SortZtoA()
        {
            loginInfo("standard_user", "secret_sauce");
            //in this step i retuern just one element  (using find elements) because in xpath all elements have unique value

            IWebElement element = TestSetup.driver.FindElement(By.XPath("//div/span/select[@class='product_sort_container']"));
            TestSetup.HighlightElement(TestSetup.driver, element);
            element.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement element1 = TestSetup.driver.FindElement(By.XPath("//div/span/select/option[@value='za']"));
            TestSetup.HighlightElement(TestSetup.driver, element1);
            element1.Click();
            System.Threading.Thread.Sleep(5000);


            // in this step i  return collect of inner text (list/array) because all cards have same xpath (in backend have one code in foreach)
            ReadOnlyCollection<IWebElement> webElements = TestSetup.driver.FindElements(By.XPath("//div//div//div[@class='inventory_item_name']"));

            //creat list to store value & casting value from string to double(in foreach i will casting it )
            string[] prices = new string[webElements.Count];


            for (int i = 0; i < webElements.Count; i++)
            {
                //to return all value(innertext) in xpath for all elements
                //.trim use to remove char from string (here use to remove $ and white space)
                prices[i] = Convert.ToString(webElements[i].GetAttribute("innerText").Trim('$', ' '));  //return value as a string using convert.toDouble its casting to double

            }
            for (int i = 0; i < prices.Length; i++)
            {
                if (i == prices.Length - 1)
                {
                    Console.WriteLine("Passed");
                    break;
                }
                //(prices[i] == prices[i + 1])
                if ( prices[i]==prices[i])
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Faild");//this result should show it in excel sheet  
                    break;
                }
            }


            Logout();

        }




        
    }
}
