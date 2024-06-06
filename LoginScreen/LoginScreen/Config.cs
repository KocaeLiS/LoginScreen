using System;
using Rocket.API;

namespace LoginScreen
{
	public class Config : IRocketPluginConfiguration, IDefaultable
	{
		public void LoadDefaults()
		{
			this.VoteUrl = "discord.gg/alcatraznetwork";
			this.DiscordUrl = "discord.gg/alcatraznetwork";
			this.PngUrl = "https://i.hizliresim.com/aermgxo.jpg";
		}

		public string VoteUrl;

		public string DiscordUrl;

		public string PngUrl;
	}
}
