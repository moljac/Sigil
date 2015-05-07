﻿using System;
using NUnit.Framework;
using System.IO;
using System.Text;

// alias to make porting from MS test framework to NUnit
using TestMethodAttribute=NUnit.Framework.TestAttribute;

namespace Sigil.XamarinAndroid.UnitTests
{ 
	[TestFixture]
	public class WriteLine
	{

		[SetUp]
		public void Setup() { }


		[TearDown]
		public void Tear() { }

		[TestMethod]
        public void WriteLineFormat()
        {
            {
                var e = Emit<Func<string>>.NewDynamicMethod();
                var a = e.DeclareLocal<string>();
                var b = e.DeclareLocal<byte>();
                var c = e.DeclareLocal<object>();
                
                e.LoadConstant("hello world");
                e.StoreLocal(a);

                e.LoadConstant(16);
                e.StoreLocal(b);

                e.LoadNull();
                e.StoreLocal(c);

                e.DeclareLocal<MemoryStream>("MemoryStream");
                e.DeclareLocal<StreamWriter>("StreamWriter");
                e.DeclareLocal<byte[]>("arr");

                e.NewObject<MemoryStream>();
                e.StoreLocal("MemoryStream");
                e.LoadLocal("MemoryStream");
                e.NewObject(typeof(StreamWriter), new[] { typeof(Stream) });
                e.StoreLocal("StreamWriter");
                e.LoadLocal("StreamWriter");
                e.Call(typeof(Console).GetMethod("SetOut"));

                e.WriteLine("a: {0}; b: {1}; c: {2}", a, b, c);

                e.LoadLocal("StreamWriter");
                e.Call(typeof(StreamWriter).GetMethod("Flush"));
                e.LoadLocal("MemoryStream");
                e.Call(typeof(MemoryStream).GetMethod("ToArray"));
                e.StoreLocal("arr");
                e.Call(typeof(Encoding).GetMethod("get_UTF8"));
                e.LoadLocal("arr");
                e.Call(typeof(Encoding).GetMethod("GetString", new[] { typeof(byte[]) }));
                e.Return();

                var del = e.CreateDelegate();
                var val = del();

                Assert.AreEqual("a: hello world; b: 16; c: \r\n", val);
            }
        }

        [TestMethod]
        public void WriteLineSimple()
        {
            var el = Emit<Func<string>>.NewDynamicMethod();
            var guid = Guid.NewGuid().ToString();

            el.DeclareLocal<MemoryStream>("MemoryStream");
            el.DeclareLocal<StreamWriter>("StreamWriter");
            el.DeclareLocal<byte[]>("arr");
            
            el.NewObject<MemoryStream>();
            el.StoreLocal("MemoryStream");
            el.LoadLocal("MemoryStream");
            el.NewObject(typeof(StreamWriter), new[] { typeof(Stream) });
            el.StoreLocal("StreamWriter");
            el.LoadLocal("StreamWriter");
            el.Call(typeof (Console).GetMethod("SetOut"));
            
            el.WriteLine(guid);
            
            el.LoadLocal("StreamWriter");
            el.Call(typeof (StreamWriter).GetMethod("Flush"));
            el.LoadLocal("MemoryStream");
            el.Call(typeof (MemoryStream).GetMethod("ToArray"));
            el.StoreLocal("arr");
            el.Call(typeof (Encoding).GetMethod("get_UTF8"));
            el.LoadLocal("arr");
            el.Call(typeof (Encoding).GetMethod("GetString", new[] { typeof(byte[]) }));
            el.Return();

            var del = el.CreateDelegate();
            var val = del();

            Assert.AreEqual(guid + Environment.NewLine, val);
        }

	}
}