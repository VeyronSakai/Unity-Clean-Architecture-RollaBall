# RollaBall_CleanArchitecture

Unityでクリーンアーキテクチャを使ってRoll a Ballを作ってみました。

I made `Roll a Ball` by using Clean Architecture in Unity.

![gif](https://github.com/VeyronSakai/RollaBall_CleanArchitecture/blob/master/Assets/RollABall.gif)

## おおまかなクラス図(Rough Class Diagram)

![ClassDiagram](https://github.com/VeyronSakai/RollaBall_CleanArchitecture/blob/master/Assets/ClassDiagram.png)

このプロジェクトではTranslator,Repository,DataStore,Structureは使っていません。

This project doesn't use Translator, Repository, DataStore and Structure. 


### Viewの役割

シーンに現れるオブジェクトの管理を担当

- インスペクタビューに表示される情報の管理
- それらの情報の更新
- それらの情報の初期化

### Presenterの役割

一言で言うとViewの管理を担当

- Viewのトリガーをまとめて、IObservableを返すメソッドを各々のトリガーに対して作る。
- (Factoryを用いて)Viewオブジェクトの生成、を扱うメソッドを持つ。
- 複数のViewインスタンスを管理するためのリストを持つ。


### UseCaseの役割

ビジネスロジックを担当

- IInitializableを継承し、Initializeメソッド内で初期化処理を行う。
- Initialize内でEntityやViewのSubjectやReactivePropertyをSubscribeする。


### Entityの役割

内部データを担当

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
