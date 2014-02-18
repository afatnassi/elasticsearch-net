﻿using Nest.Tests.MockData.Domain;
using NUnit.Framework;

namespace Nest.Tests.Integration.Indices
{
	[TestFixture]
	public class OptimizeTests : IntegrationTests
	{
		[Test]
		public void OptimizeAll()
		{
			var r = this._client.Optimize();
			Assert.True(r.Acknowledged, r.ConnectionStatus.ToString());
		}
		[Test]
		public void OptimizeIndex()
		{
			var r = this._client.Optimize(o=>o.Index(ElasticsearchConfiguration.DefaultIndex));
			Assert.True(r.Acknowledged);
		}
		[Test]
		public void OptimizeIndices()
		{
			var r = this._client.Optimize(o=>o.Indices(ElasticsearchConfiguration.DefaultIndex, ElasticsearchConfiguration.DefaultIndex + "_clone" ));
			Assert.True(r.Acknowledged);
		}
		[Test]
		public void OptimizeTyped()
		{
			var r = this._client.Optimize(o=>o.Index<ElasticsearchProject>());
			Assert.True(r.Acknowledged);
		}
		public void OptimizeAllWithParameters()
		{
			var r = this._client.Optimize(o=>o.MaxNumSegments(2));
			Assert.True(r.Acknowledged, r.ConnectionStatus.ToString());
		}

	}
}