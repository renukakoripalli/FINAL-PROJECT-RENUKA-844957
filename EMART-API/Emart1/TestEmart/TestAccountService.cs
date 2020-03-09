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
                Bid = "E0002",
                Username = "jyotsna",
                Password = "jyo123",
                Emailid = "j@gmail.com",
                Mobilenumber = "9800987898",
                Createddatetime = DateTime.Now
            });
            var result = _repo.BuyerLogin("jyotsna", "jyo123");
            Assert.NotNull(result);
        }
        [Test]
        public void TestSellerRegister()
        {
            _repo.adds(new Seller()
            {
                Sid = "S0004",
                Username = "vigu",
                Password = "vigu123",
                Companyname = "vigu",
                Gstin = "grgt",
                Briefaboutcompany = "nothing",
                Postaladdress = "Attili",
                Website = "w3",
                Emailid = "v@g",
                Contactnumber = "9877890987",
            });
            var result = _repo.logins("vigu", "vigu123");
            Assert.NotNull(result);
        }
        [Test]
        public void TestLoginBuyer()
        {
            var result = _repo.BuyerLogin("jyotsna", "jyo123");
            Assert.NotNull(result);
        }
        [Test]
        public void TestSellerBuyer()
        {
            var result = _repo.logins("renu", "renuka@");
            Assert.NotNull(result);
        }

    }
}
