using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BuyerServices.Models;
using BuyerServices.Repositories;
namespace TestEmart
{
    public class TestBuyerService
    {
        BuyerRep _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new BuyerRep(new EmartDBContext());
        }
        [Test]
        public void TestBuyItem()
        {
            _repo.BuyItem(new Purchase()
            {
                Pid = "P001",
                Sid = "S0002",
                Bid = "E0001",
                Iid = "I0006",
                Transactiontype = "debit",
                Noofitems = 3,
                Datetime = DateTime.Now,
                Remarks = "good",
                Transactionstatus = "paid"
            });
            var result = _repo.PurchaseHistory("E0001");
            Assert.NotNull(result);
        }
        [Test]
        public void TestBuyerUpdate()
        {
            Buyer buyer = _repo.GetProfile("E0001");
            buyer.Username = "renuka";
            _repo.Editprofile(buyer);
            Buyer buyer1 = _repo.GetProfile("E0001");
            Assert.AreSame(buyer, buyer1);
        }
        [Test]
        public void TestGetallBuyer()
        {

            var result = _repo.Getall();
            Assert.IsNotNull(result);
            Assert.Greater(result.Count, 0);

        }
        [Test]
        public void TestGetProfileById()
        {
            var result = _repo.GetProfile("E0001");
            Assert.IsNotNull(result);
        }
        [Test]
        public void TestGetsubcategory()
        {
            var result = _repo.GetSubCategories("C0001");
            Assert.IsNotNull(result);
        }
        [Test]
        public void TestGetPurchaseHistory()
        {
            var result = _repo.PurchaseHistory("E0001");
            Assert.IsNotNull(result);
        }
        [Test]
        public void TestGetCategories()
        {

            var result = _repo.GetCategories();
            Assert.IsNotNull(result);
            Assert.Greater(result.Count, 0);

        }
        [Test]
        public void TestSearchitems()
        {
            var result = _repo.search("grg");
            Assert.IsNotNull(result);
        }
        [Test]
        public void TestGetallItems()
        {

            var result = _repo.GetAllItems();
            Assert.IsNotNull(result);
            Assert.Greater(result.Count, 0);

        }
        [Test]
        public void TestAddtocart()
        {
            _repo.AddToCart(new Cart()
            {
                Cartid="c0001",
                Iid="54",
                Bid="E0001",
                Categoryid="C0002",
                Subcategoryid="s0003",
                Price=7777,
                Itemname="grg",
                Description="good",
                Stock=3,
                Remarks="no",
            });
            var result = _repo.GetCartItems();
            Assert.NotNull(result);
        }
        [Test]
        public void TestGetcartitems()
        {

            var result = _repo.GetCartItems();
            Assert.IsNotNull(result);
            Assert.Greater(result.Count, 0);

        }
        [Test]
        public void TestDeletecartitems()
        {
            
                _repo.DeleteCartItem("c0001");
                var result = _repo.Getcartitembyid("c0001");
                Assert.Null(result);
            
        }
    }
}
