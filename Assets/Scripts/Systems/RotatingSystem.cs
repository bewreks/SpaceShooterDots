using Aspects;
using Components;
using Unity.Burst;
using Unity.Entities;

namespace Systems
{
	[UpdateBefore(typeof(MovingSystem))]
	public partial struct RotatingSystem : ISystem
	{
		public void OnUpdate(ref SystemState state)
		{
			new RotatingJob
			{
				deltaTime     = SystemAPI.Time.DeltaTime
			}.ScheduleParallel();
		}
	}
	
	[BurstCompile]
	public partial struct RotatingJob : IJobEntity
	{
		public float deltaTime;

		public void Execute(RotationAspect aspect)
		{
			aspect.Rotate(deltaTime);
		}
	}
}