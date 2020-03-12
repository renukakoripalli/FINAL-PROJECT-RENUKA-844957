using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SellerServices.Models;
using SellerServices.Repositories;

namespace TestEmart
{
    [TestFixture]
    class TestItemService
    {
        ItemRepository _repo;
        [SetUp]
        public void Setup()
        {
            _repo = new ItemRepository(new EmartDBContext());
        }
        [Test]
        public void TestAddItems()
        {
            _repo.AddItem(new Items()
            {
                Iid = "I099",
                Itemname = "note7",
                Price = 12999,
                Stocknumber = 5,
                Sid = "S0002",
                Categoryid = "C0001",
                Subcategoryid = "s0001",
                Description = "ram 8gb",
                Remarks = "6months warranty",
               
            });
            var result = _repo.GetItems("I099");
            Assert.NotNull(result);
        }
        [Test]
        public void TestViewItems()
        {
            var result = _repo.Viewitems("46");
            Assert.NotNull(result);
        }
        [Test]
        public void TestDeleteItem()
        {
            _repo.DeleteItem("I099");
            var result = _repo.GetItems("I099");
            Assert.Null(result);
        }
        [Test]
        public void TestUpdateItem()
        {
            Items items = _repo.GetItems("46");
            items.Price = 23990;
            _repo.UpdateItem(items);
            Items items1 = _repo.GetItems("46");
            Assert.AreSame(items, items1);

        }
        [Test]
        public void TestGetAllCategories()
        {
            var result = _repo.GetCategory();
            Assert.NotNull(result);
        }
        [Test]
        public void TestSubCategory()
        {
            var result = _repo.GetSubCagegory("C0001");
            Assert.NotNull(result);
        }
    }
}
