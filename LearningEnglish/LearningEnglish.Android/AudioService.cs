﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningEnglish.Droid
{
	public class AudioService //: IAudio
	{
		public AudioService()
		{
		}

		//public void PlayAudioFile(string fileName)
		//{
		//	var player = new MediaPlayer();
		//	var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
		//	player.Prepared += (s, e) =>
		//	{
		//		player.Start();
		//	};
		//	player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
		//	player.Prepare();
		//}
	}
}