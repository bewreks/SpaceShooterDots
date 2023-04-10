using Aspects;
using Components;
using Unity.Burst;
using Unity.Entities;

namespace Systems
{
	[BurstCompile]
	[UpdateAfter(typeof(UserInputSystem))]
	public partial struct MovingSystem : ISystem
	{
		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			var gameEntity   = SystemAPI.GetSingletonEntity<GameProperties>();
			var gameAspect   = SystemAPI.GetAspectRO<GameAspect>(gameEntity);
			var ecbSingleton = SystemAPI.GetSingleton<EndInitializationEntityCommandBufferSystem.Singleton>();

			new MovingJob
			{
				ecb           = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter(),
				deltaTime     = SystemAPI.Time.DeltaTime,
				frictionForce = gameAspect.FrictionForce
			}.ScheduleParallel();
		}
	}

	[BurstCompile]
	public partial struct MovingJob : IJobEntity
	{
		public float deltaTime;
		public float frictionForce;

		public EntityCommandBuffer.ParallelWriter ecb;

		public void Execute(MovingAspect aspect, [EntityIndexInQuery] int index)
		{
			aspect.Move(frictionForce, deltaTime);

			if (aspect.CurrentSpeed <= 0)
			{
				ecb.SetComponentEnabled<MovingComponent>(index, aspect.entity, false);
			}
		}
	}
}