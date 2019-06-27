# Unity-Clean-Architecture-RollaBall

Unityでクリーンアーキテクチャを使ってRoll a Ballを作ってみました。

I made `Roll a Ball` by using Clean Architecture in Unity.

![gif](https://github.com/VeyronSakai/RollaBall_CleanArchitecture/blob/master/Assets/RollABall.gif)

## おおまかなクラス図(Rough Class Diagram)

![ClassDiagram](https://github.com/VeyronSakai/RollaBall_CleanArchitecture/blob/master/Assets/ClassDiagram.png)

このプロジェクトではTranslator,Repository,DataStore,Structureは使っていません。

This project doesn't use Translator, Repository, DataStore and Structure. 


### Viewの役割 (Role of View)

シーンに現れるオブジェクトの管理を担当 (management of the objects appearing in the scene)

- インスペクタビューに表示される情報の管理 (management of the information of the inspector)
- それらの情報の更新 (update of those information)
- それらの情報の初期化 (initialization of those information)

### Presenterの役割 (Role of Presenter)

Viewの管理を担当 (management of the views)

- Viewのトリガーをまとめて、IObservableを返すメソッドを各々のトリガーに対して作る。 (making the methods returning IObservable for triggers of the views)
- (Factoryを用いて)Viewオブジェクトの生成、を扱うメソッドを持つ。 ((By using Factory) having methods to create view objects)
- 複数のViewインスタンスを管理するためのリストを持つ。 (having the lists which manage multiple views)


### UseCaseの役割 (Role of UseCase)

ビジネスロジックを担当 (bisiness logic)

- IInitializableを継承し、Initializeメソッド内で初期化処理を行う。(initializing in Initialize method)
- Initialize内でEntityやViewのSubjectやReactivePropertyをSubscribeする。 (subscribing Subject and ReactiveProperty in Initialize method)


### Entityの役割 (Role of Entity)

内部データを担当 (managing the internal data)

- 各オブジェクトの状態をSubjectで管理する 
- 内部データをReactivePropertyで管理する
- ReactivePropertyを更新したり、SubjectにOnNextしたりOnCompleteするためのメソッドを持つ

## 使用ライブラリ(Used Library)

- [Unity](https://unity.com) 2019 1.6f1 (c) Unity Technologies ApS.

- [UniRx](https://github.com/neuecc/UniRx) 6.2.2 The MIT License (MIT) Copyright (c) 2018 Yoshifumi Kawai.

- [Zenject](https://github.com/modesttree/Zenject) 7.3.1 Copyright (c) 2010-2019 Modest Tree Media Inc.

## 参考(Reference)

- [cafu_sample](https://github.com/monry/cafu_sample) Copyright (c) 2018 Tetsuya Mori

- [cafu_core](https://github.com/umm/cafu_core) Copyright (c) 2017-2018 Tetsuya Mori
