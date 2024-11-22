# Road Runner
## 프로젝트 소개

플레이어가 광산을 탐험하는 캐주얼 액션 게임입니다.  몬스터를 죽이면서 코인을 얻고, 아이템으로 파워업을하여 동굴을 탈출합니다.

### InputSystem

InputSystem Package 활용, 키보드로 조작

- 좌우 이동:  W, A, S, D
- 점프: Space
- 공격: 마우스 우클릭

### Main Contents

- 얻은 목숨, 코인 개수에 따라 우상단에 점수 업데이트
- 몬스터나 장애물에 부딪치면 라이프 차감
- 모든 라이프 소진 시 게임 오버 창 활성화, 다시 시작 버튼 클릭 시 재시작
- 게임이 진행되는 Scene 로드되면 자동으로 맵 동적 생성 후 재배치
- 몬스터 죽을시 일정 확률로 스피드업 아이템, 파워업 아이템, 목숨, 코인 드랍
- 스피드업 - 플레이어 이동속도가 증가
- 파워업 - 플레이어 공격력이 증가
- 목숨 - 라이프 증가

### Item

- 스피드업 - 플레이어 이동속도가 증가
- 파워업 - 플레이어 공격력이 증가
- 목숨 - 라이프 증가

### 플레이 영상
추가예정

## 개발 과정

### 개발 환경

- 게임엔진: Unity
- IDE: VisualStudio 2022, VisualStudio Code, Rider
- 협업 툴: Github, GitMind

### 개발 기간

2024.10.31 - 2024.11.06 (7일)

### 역할 분담

| 이름 | 역할 | 담당 업무 |
| --- | --- | --- |
| 이상운 | 팀장 | 아이템 |
| 백승우 | 팀원 | 몬스터|
| 최  빈 | 팀원 | 플레이어 |
| 이준형 | 팀원 | UI |

## 주요 기능

- **동적 생성**: 초기 Scene에는 동적 생성에 필요한 인스턴스만 배치하고 나머지는 Scene이 로드될 때 생성하도록 설계
- **오브젝트 풀링**: 몬스터, 파이어, 장애물 등 게임 오브젝트를 효율적으로 관리하며 새로 생성하는 대신 재사용
- **버프:** 아이템으로 인한 버프

## 와이어프레임
- 초기버전
https://docs.google.com/drawings/d/1IWGt1gAPaFoUjvxOJcfKfIugNmSjJ2LMGAa0gnN7aps/edit


## 주요 로직 클래스

### 1. **GameManager** (게임 상태 관리)

- 주요 게임 상태(시작, 게임 플레이, 게임 오버) 제어
- 점수, 생명, 파워업, 업적 관리

### 2. **PlayerController** (플레이어 이동 및 상호작용)

- 플레이어 입력, 이동, 점프 및 슬라이드 애니메이션을 처리
- 플레이어와 장애물의 충돌 판정

### 3. Road, Building, ObstacleManager (맵 생성)

- **오브젝트 풀링**: RoadManager로 Road 인스턴스를 풀링하여 리소스 절약
- **생성 및 재배치 로직**: Building, Hurdle 인스턴스가 카메라 촬영 범위 밖으로 이동하면 새 위치로 재배치하여 무한 맵 생성
