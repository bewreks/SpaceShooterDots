using Components;
using Unity.Entities;

namespace Aspects
{
	public readonly partial struct GameAspect : IAspect
	{
		public readonly Entity entity;

		private readonly RefRO<GameProperties> _properties;

		public Entity PlayerEntity       => _properties.ValueRO.playerPrefab;
		public float  PlayerMaxSpeed     => _properties.ValueRO.playerMaxSpeed;
		public float  PlayerAcceleration => _properties.ValueRO.playerAcceleration;
		public float  FrictionForce      => _properties.ValueRO.frictionForce;
		public float  MaxRotationSpeed   => _properties.ValueRO.maxRotationSpeed;
	}
}