using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SellerServices.Models;
using SellerServices.Repositories;

namespace TestEmart
{
    [TestFixture]
    class TestSellerService
    {
        SellerRepository _repo;
        [SetUp]
        public void Setup()
        {
            _repo = new SellerRepository(new EmartDBContext());
        }
        [Test]
        public void TestGetProfile()
        {
            var result = _repo.GetProfile("12345");
            Assert.IsNotNull(result);
        }
        [Test]
        public void TestSellerUpdate()
        {
            Seller seller = _repo.GetProfile("2");
            seller.Gstin = "ttttt";
            _repo.EditProfile(seller);
            Seller seller1 = _repo.GetProfile("2");
            Assert.AreSame(seller, seller1);
        }
    }
}