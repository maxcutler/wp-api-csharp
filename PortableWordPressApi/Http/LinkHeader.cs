using System;
using System.Linq;

namespace PortableWordPressApi.Http
{
	internal class LinkHeader
	{
		public LinkHeader(string header)
		{
			var bits = header.Split(';');
			if (bits.Length < 2)
			{
				throw new ArgumentException("Invalid Link header value", "header");
			}

			var linkBit = bits[0].Trim();
			if (linkBit[0] != '<' || linkBit[linkBit.Length-1] != '>')
			{
				throw new ArgumentException("Invalid Link header value", "header");
			}

			var link = linkBit.Substring(1, linkBit.Length - 2);
			this.LinkUri = new Uri(link, UriKind.RelativeOrAbsolute);

			for (var i = 1; i < bits.Length; i++)
			{
				var token = bits[i];
				var tokenBits = token.Trim().Split('=');
				if (tokenBits[0] == "rel" && tokenBits.Length > 1)
				{
					this.Relation = tokenBits[1].Trim('"');
				}
			}

		}

		public Uri LinkUri
		{
			get;
			private set;
		}

		public string Relation
		{
			get;
			private set;
		}
	}
}
