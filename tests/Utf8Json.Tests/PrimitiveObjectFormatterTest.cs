﻿using System;
using System.Collections.Generic;
using System.Text;
using Spreads.Serialization.Utf8Json.Formatters;
using Xunit;

namespace Spreads.Serialization.Utf8Json.Tests
{
    public class PrimitiveObjectFormatterTest
    {
        [Fact]
        public void Collection()
        {
            var jw = new JsonWriter(Array.Empty<byte>());
            PrimitiveObjectFormatter.Default.Serialize(ref jw, new[] { "foo", "bar", "baz" }, null);

            jw.ToString().Is("[\"foo\",\"bar\",\"baz\"]");
        }

        [Fact]
        public void Map()
        {
            var jw = new JsonWriter(Array.Empty<byte>());
            PrimitiveObjectFormatter.Default.Serialize(ref jw, new Dictionary<string, int> { { "foo", 10 }, { "bar", 99 }, { "baz", 100 } }, null);

            jw.ToString().Is("{\"foo\":10,\"bar\":99,\"baz\":100}");
        }
    }
}
