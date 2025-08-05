

# 🎮 Player StateMachine

## 📖 도입 배경
이 시스템은 **플레이어 캐릭터의 상태 기반 AI(FSM)** 구조를 관리하는 `PlayerStateMachine` 클래스입니다.  
각각의 상태는 `StateMachine`을 상속받아 독립적으로 관리되며, 상태 전환을 통해 플레이어의 행동을 제어합니다.

 이 시스템은 **플레이어의 공격, 이동, 스킬 사용, 회피, 사망 등의 상태**를 관리합니다.

FSM은 Enemy AI쪽과 같이 사용하기 때문에 제외하였습니다.

## 🧱 코드

### [PlayerStateMachine](./PlayerStateMachine.cs)
- **Script명**: `PlayerStateMachine`  

- **설명**: 플레이어의 상태 전환 및 각 상태에 따른 행동을 관리하는 FSM 시스템입니다. 이동, 공격, 회피, 스킬, 사망 등을 상태로 분리하여 관리하며, 각 상태에서 필요한 행동을 수행합니다.

  

| 기능          | 설명                                                     | 클래스명                                        |
| :------------ | -------------------------------------------------------- | ----------------------------------------------- |
| InputReader   | 사용자 입력을 처리하는 클래스                            | [InputReader](../../InputReader.cs)             |
| ForceReceiver | 캐릭터가 받는 힘(Impact)과 중력을 처리하는 클래스        | [ForceReceiver](../../../ForceReceiver.cs)        |
| Targeter      | 플레이어가 타겟을 자동으로 선택하고 표시하는 클래스      | [Targeter](../../../Combat/Targeter.cs)         |
| WeaponDamage  | 무기의 피해 및 넉백 처리를 담당하는 클래스               | [WeaponDamage](../../../Combat/WeaponDamage.cs) |
| Attack        | **플레이어의 공격에 관련된 정보를 저장**하는 데이터 구조 | [Attack](../Attack.cs)                          |



