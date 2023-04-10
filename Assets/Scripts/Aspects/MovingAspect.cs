using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Aspects
{
	public readonly partial struct MovingAspect : IAspect
	{
		public readonly Entity entity;

		private readonly RefRW<LocalTransform>     _transform;
		private readonly RefRW<SpeedComponent>     _speed;
		private readonly RefRW<MovingComponent>    _moving;
		private readonly RefRW<DirectionComponent> _direction;

		public float CurrentSpeed => math.length(_direction.ValueRO.direction);

		public void Move(float frictionForce, float deltaTime)
		{
			_direction.ValueRW.direction = Float3Extensions.MoveTowards(_direction.ValueRO.direction, 
			                                                            0, 
			                                                            frictionForce * deltaTime);
			_direction.ValueRW.direction += _moving.ValueRO.curAcceleration * deltaTime * _transform.ValueRW.Forward();
			_direction.ValueRW.direction =  Float3Extensions.ClampMagnitude(_direction.ValueRO.direction, 1);
			
			_transform.ValueRW.Position += _speed.ValueRO.maxSpeed * deltaTime * _direction.ValueRO.direction;
		}

		public void StartAcceleration()
		{
			_moving.ValueRW.curAcceleration = _moving.ValueRO.acceleration;
		}

		public void EndAcceleration()
		{
			_moving.ValueRW.curAcceleration = 0;
		}
	}
}