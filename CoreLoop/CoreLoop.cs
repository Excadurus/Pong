using ConsoleRenderer;
using PhysicsEngine;
using System;
using System.Threading;

namespace Logic
{
	public abstract class CoreLoop
	{
		bool isFinished = false;
		protected readonly GeneralPhysicsEngine physicsEngine = new GeneralPhysicsEngine();
		protected readonly RenderShape renderer = new RenderShape();
		protected double fps;

		public CoreLoop()
		{
		}

		public void RunCoreLoop()
		{
			while (!isFinished)
			{
				OnBeforePhysic();

				physicsEngine.Update();

				OnAfterPhysic();

				renderer.Render();
				Thread.Sleep((int)(1000.0/fps));
			}
		}

		protected abstract void OnBeforePhysic();
		protected abstract void OnAfterPhysic();

		protected void Exit()
		{
			isFinished = true;
		}
	}
}
