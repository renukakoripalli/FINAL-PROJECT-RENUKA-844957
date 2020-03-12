using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AdminServices.Models;
using AdminServices.Repositories;
namespace TestEmart
{
    public class TestAdminService
    {
        AdminRepository _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new AdminRepository(new EmartDBContext());
        }
        [Test]
        [Description("Test Add Category")]
        public void TestAddCategory()
        {
            _repo.AddCategories(new Category()
            {
                Categoryid="C0009",
                Categoryname="Iron1",
                Briefdetails="iron"
            });
            var result = _repo.ViewCategory();
            Assert.NotNull(result);
        }
        [Test]
        public void TestAddSubcategory()
        {
            _repo.AddSubCategories(new Subcategory()
            {
                Subcategoryid = "s0006",
                Subcategoryname = "Box",
                Categoryid = "C0006",
                Briefdetails = "its box",
                Gst = 12
            });
            var result = _repo.ViewSubCategory();
            Assert.NotNull(result);
        }
        [Test]
        public void TestDeleteCategory()
        {
            _repo.DeleteCategory("C0009");
            var result = _repo.Getbycatid("C0009");
            Assert.Null(result);
        }
        [Test]
        public void TestDeleteSubcategory()
        {
            _repo.DeleteSubCategory("s0006");
            var result = _repo.Getbyscatid("s0006");
            Assert.Null(result);
        }
        [Test]
        public void TestViewCategory()
        {
            var result = _repo.ViewCategory();
            Assert.NotNull(result);
        }
        [Test]
        public void TestViewSubCategory()
        {
            var result = _repo.ViewSubCategory();
            Assert.NotNull(result);
        }
        [Test]
        public void TestUpdatecat()
        {
           
                Category category = _repo.Getbycatid("C0001");
                category.Briefdetails = "Chocolates";
                _repo.EditCategory(category);
                Category category1 = _repo.Getbycatid("C0001");
                Assert.AreSame(category, category1);
            
        }
        [Test]
        public void TestUpdatescat()
        {

            Subcategory subcategory = _repo.Getbyscatid("s0001");
            subcategory.Briefdetails = "Chocolate";
            _repo.EditSubcategory(subcategory);
            Subcategory subcategory1 = _repo.Getbyscatid("s0001");
            Assert.AreSame(subcategory, subcategory1);

        }
    }
}
