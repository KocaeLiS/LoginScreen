using System;
using Rocket.API;
using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace LoginScreen
{
	public class Main : RocketPlugin<Config>
	{
		protected override void Load()
		{
			U.Events.OnPlayerConnected += new UnturnedEvents.PlayerConnected(this.Events_OnPlayerConnected);
			EffectManager.onEffectButtonClicked += this.OnButtonClicked;
		}

		protected override void Unload()
		{
			U.Events.OnPlayerConnected -= new UnturnedEvents.PlayerConnected(this.Events_OnPlayerConnected);
			EffectManager.onEffectButtonClicked -= this.OnButtonClicked;

		}

		private void Events_OnPlayerConnected(UnturnedPlayer player)
		{
			player.Player.enablePluginWidgetFlag((EPluginWidgetFlags)1);
			player.Player.enablePluginWidgetFlag((EPluginWidgetFlags)4);
			EffectManager.sendUIEffect(2424, 2424, player.CSteamID, false);
			EffectManager.sendUIEffectImageURL(2424, player.CSteamID, true, "logo_case", base.Configuration.Instance.PngUrl);
		}

		public static void OpenUrl(UnturnedPlayer player, string url, string desc)
		{
			player.Player.sendBrowserRequest(desc, url);
		}

		public void OnButtonClicked(Player caller, string buttonName)
		{
			UnturnedPlayer unturnedPlayer = UnturnedPlayer.FromPlayer(caller);
			bool flag = buttonName == "play_button";
			bool flag2 = flag;
			if (flag2)
            {
                EffectManager.askEffectClearByID(2424, UnturnedPlayer.FromPlayer(caller).CSteamID);
				unturnedPlayer.Player.disablePluginWidgetFlag((EPluginWidgetFlags)1);
				unturnedPlayer.Player.disablePluginWidgetFlag((EPluginWidgetFlags)4);
			}
            bool flag3 = buttonName == "discord_button";
			bool flag4 = flag3;
			if (flag4)
			{
				unturnedPlayer.Player.sendBrowserRequest("Discord Link:", base.Configuration.Instance.DiscordUrl);
			}
			bool flag5 = buttonName == "vote_button";
			bool flag6 = flag5;
			if (flag6)
			{
				unturnedPlayer.Player.sendBrowserRequest("Sunucuya Oy Vermek İçin:", base.Configuration.Instance.VoteUrl);
			}
			bool flag7 = buttonName == "exit_button";
			bool flag8 = flag7;
			if (flag8)
			{
				string displayName = unturnedPlayer.DisplayName;
				unturnedPlayer.Kick("Sunucudan Çıktınız.");
			}
		}
	}
}
