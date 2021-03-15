using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Testing.test
{
    [TestClass]
    public class Studentshould
    {
        [TestMethod]
        public void BeThere()
        {
            var Student = new Studenten_Volg_Systeem.Models.Student();
            Student.Id = 0;
            Assert.IsTrue(Student.Id == 0);
        }
    }
       
}


//[TestClass]
//public class bucketshould
//{
//    [TestMethod]
//    public void Beempty()
//    {
//        var bucket = new Bucket_OOP_Opdracht.bucket();
//        Assert.IsTrue(bucket.Content == 0);
//    }

//    [TestMethod]
//    public void BeDefaultCapacety()
//    {
//        var bucket = new Bucket_OOP_Opdracht.bucket();
//        Assert.IsTrue(bucket.Capacety == 12);
//    }

//    [TestMethod]
//    public void BeCustomCapacety()
//    {
//        var bucket = new Bucket_OOP_Opdracht.bucket(3);
//        Assert.IsTrue(bucket.Capacety == 3);
//    }

//    [TestMethod]
//    public void bePartiallyFilled()
//    {
//        var bucket = new Bucket_OOP_Opdracht.bucket();
//        bucket.Fill(2);
//        Assert.AreEqual(bucket.Content, 2);

//    }

//    [TestMethod]
//    public void beFilledByOtherBucket()
//    {
//        var bucket1 = new Bucket_OOP_Opdracht.bucket();
//        var bucket2 = new Bucket_OOP_Opdracht.bucket();
//        bucket1.Fill(6);
//        bucket2.Fill(bucket1);
//        Assert.AreEqual(bucket2.Content, 6);
//        Assert.AreEqual(bucket1.Content, 0);

//    }

//    [TestMethod]
//    public void beAbleToOverflow()
//    {
//        bool trigger = false;
//        var bucket = new Bucket_OOP_Opdracht.bucket();
//        bucket.Fill(15);
//        Assert.AreEqual(bucket.Content, bucket.Capacety);
//        bucket.test += delegate ()
//        {
//            trigger = true;
//        };
//        Assert.AreEqual(bucket.Content, bucket.Capacety);
//        Assert.IsTrue(trigger);
//    }
//}

//[TestClass]
//public class OilBarrelShould
//{
//    [TestMethod]
//    public void beEmpty()
//    {
//        var barrel = new Bucket_OOP_Opdracht.models.oilbarrel();
//        Assert.AreEqual(barrel.Content, 0);
//    }

//    [TestMethod]
//    public void be159Liter()
//    {
//        var barrel = new Bucket_OOP_Opdracht.models.oilbarrel();
//        Assert.AreEqual(barrel.Capacety, 159);
//    }
//}

//[TestClass]
//public class RainBucketShould
//{
//    [TestMethod]
//    public void beEmpty()
//    {
//        var bucket = new Bucket_OOP_Opdracht.models.RainBucket("smalll");
//        Assert.AreEqual(bucket.Content, 0);
//    }

//    [TestMethod]
//    public void beSmall()
//    {
//        var bucket = new Bucket_OOP_Opdracht.models.RainBucket("small");
//        Assert.AreEqual(bucket.Capacety, 80);
//    }

//    [TestMethod]
//    public void beMedium()
//    {
//        var bucket = new Bucket_OOP_Opdracht.models.RainBucket("medium");
//        Assert.AreEqual(bucket.Capacety, 120);
//    }

//    [TestMethod]
//    public void beLarge()
//    {
//        var bucket = new Bucket_OOP_Opdracht.models.RainBucket("large");
//        Assert.AreEqual(bucket.Capacety, 160);
//    }
//}

