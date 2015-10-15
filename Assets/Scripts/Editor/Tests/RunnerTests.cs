using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest
{
	[TestFixture]
	[Category("Runner Tests")]
	internal class RunnerTests
	{
		[Test]
		[Category("Player Tests")]
		public void ExceptionTest()
		{
			throw new Exception("Exception throwing test");
		}
	}
}
