using System;
using System.Threading;

namespace ConProgBarSharp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			ConProgBar bar = new()
			{
				ShowEta = true,
				InsertColorMarkers = ConProgBar.InsertRainbowColorMarkers,
				Text = "Demoing"// + " with a very long title to see if the caption truncation does work as intended"
			};

			TaskbarProgress tbProg = new NullTaskbarProgress();
			//if (OperatingSystem.IsWindows())
			//{
			//	tbProg = new WinTaskbarProgress() { Handle = WinTaskbarProgress.FindConsoleWindowHandle() };
			//}
			tbProg = new TerminalTaskbarProgress();

			try
			{
				int conWidth = Console.WindowWidth - 1;
				if (conWidth < 20)
				{
					Console.WriteLine($"Console Width = {conWidth} too narrow!");
					conWidth = 20;
				}
				bar.MaximumWidth = conWidth;
			}
			catch
			{
				// console will not support width query if run in CI
				bar.MaximumWidth = 40;
			}
			bar.MinimumWidth = bar.MaximumWidth;

			tbProg.SetState(TaskbarProgress.State.Indeterminate);
			bar.Show = true;

			const int maxI = 18;
			for (int i = 0; i < maxI; ++i)
			{
				bar.Value = (double)i / maxI;
				tbProg.SetValue((ulong)i, maxI);

				Thread.Sleep(500);
				//if (i % 5 == 1)
				//{
				//	Thread.Sleep(TimeSpan.FromSeconds(2));
				//}

				if (i == 10)
				{
					bar.Show = false;
					Console.WriteLine("Intermission...");
					tbProg.SetState(TaskbarProgress.State.Paused); // pause = yellow/warning
					Thread.Sleep(2000);
					tbProg.SetState(TaskbarProgress.State.Normal);

					bar.Show = true;
				}

			}

			bar.Show = false;
			tbProg.SetState(TaskbarProgress.State.None);

			Console.WriteLine("Done.");
		}
	}
}
