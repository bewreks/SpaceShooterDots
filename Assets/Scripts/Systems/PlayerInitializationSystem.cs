using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Systems
{
	[BurstCompile]
	[UpdateInGroup(typeof(InitializationSystemGroup))]
	public partial struct PlayerInitializationSystem : ISystem
	{
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<GameProperties>();
		}

		public void OnUpdate(ref SystemState state)
		{
			state.Enabled = false;

			var gameEntity = SystemAPI.GetSingletonEntity<GameProperties>();
			var gameAspect = SystemAPI.GetAspectRO<Aspects.GameAspect>(gameEntity);

			var buffer       = new EntityCommandBuffer(Allocator.Temp);
			var playerEntity = buffer.Instantiate(gameAspect.PlayerEntity);

			buffer.AddComponent<PlayerTag>(playerEntity);

			buffer.AddComponent(playerEntity, new MovingComponent
			                                  {
				                                  acceleration = gameAspect.PlayerAcceleration
			                                  });

			buffer.AddComponent(playerEntity, new RotatingComponent
			                                  {
				                                  curRotation      = 0,
				                                  curRotationSpeed = 0,
				                                  maxRotationSpeed = gameAspect.MaxRotationSpeed
			                                  });

			buffer.AddComponent(playerEntity, new SpeedComponent
			                                  {
				                                  maxSpeed = gameAspect.PlayerMaxSpeed
			                                  });

			buffer.AddComponent(playerEntity, new DirectionComponent
			                                  {
				                                  direction = 0
			                                  });

			buffer.SetComponentEnabled<MovingComponent>(playerEntity, false);
			buffer.SetComponentEnabled<RotatingComponent>(playerEntity, false);

			buffer.Playback(state.EntityManager);
		}
	}
}