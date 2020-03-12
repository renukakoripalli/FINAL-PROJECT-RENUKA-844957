using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AccountServices.Models;
using AccountServices.Repositories;
namespace TestEmart
{
   public class TestAccountService
    {
        AccountRepository _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new AccountRepository(new EmartDBContext());
        }
        [Test]
        public void TestBuyerRegister()
        {
            _repo.addb(new Buyer()
            {
                Bid = "E0007",
                Username = "jyotsna",
                Password = "jyo1234",
                Emailid = "j@gmail.com",
                Mobilenumber = "9800987898",
                Createddatetime = DateTime.Now
            });
            var result = _repo.BuyerLogin("jyotsna", "jyo1234");
            Assert.NotNull(result);
        }
        [Test]
        public void TestSellerRegister()
        {
            _repo.adds(new Seller()
            {
                Sid = "S0005",
                Username = "vigu",
                Password = "vigu1234",
                Companyname = "vigu",
                Gstin = "grgt",
                Briefaboutcompany = "nothing",
                Postaladdress = "Attili",
                Website = "w3",
                Emailid = "v@g",
                Contactnumber = "9877890987",
            });
            var result = _repo.logins("vigu", "vigu1234");
            Assert.NotNull(result);
        }
        [Test]
        public void TestLoginBuyer()
        {
            var result = _repo.BuyerLogin("jyotsna", "jyo1234");
            Assert.NotNull(result);
        }
        [Test]
        public void TestLoginSeller()
        {
            var result = _repo.logins("renuka", "renuka@");
            Assert.NotNull(result);
        }

    }
}
