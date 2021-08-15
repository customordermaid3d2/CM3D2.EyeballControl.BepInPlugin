# 포함된 내용

- 기어 메뉴 추가  
- 설정파일에 값 저장  
- 단축키 설정  
- GUI 기본 작성. 윈도우 리사이즈시 밖으로 나가버리는거 방지 포함  
- 코루틴  
- 하모니  
- OnSceneLoaded 기본 사용법.  scene.buildIndex는 쓰지 말자 제발.  

바로 컴파일 할수 있게 BepInPluginSample/lib/ 폴더 안에 dll 들어 있음.  
게임 버전에 맞게 기존 게임 폴더에서 가져다 쓸것.  


# 샘플 이미지

![2021-06-06 19 16 10](https://user-images.githubusercontent.com/20321215/120920873-f7b72d00-c6fb-11eb-80a7-8e9e73d3a013.png)
  
  

# 설치 위치

COM3D2\BepInEx\plugins  
  
  
# 필요한거
  
- BepInEx https://github.com/BepInEx/BepInEx  
- SybarisLoader https://github.com/BepInEx/BepInEx.SybarisLoader.Patcher  
- UnityInjectorLoader https://github.com/BepInEx/BepInEx.UnityInjectorLoader  
  
- COM3D2.API.dll  https://github.com/DeathWeasel1337/COM3D2_Plugins/releases/download/v3/COM3D2.API.v1.0.zip
- LillyUtill 21.7.22 over https://github.com/customordermaid3d2/COM3D2.LillyUtill/releases  
  
  
# 원본

https://ux.getuploader.com/galleBlizzg/download/17  
  

## readme.txt

■ これは何？  
スタジオモードで対象のメイドの眼球を制御します  
  
  
■ 前提  
しばりす2.2 導入済み  
  
COM3D2 ver2.3.0 で確認  
  
■ 導入  
SybarisフォルダにUnityInjectorフォルダを置いてください  
  
■ 更新履歴   
※ 詳細は使い方をご覧ください  
1.0.0 - リリース  
  
■ 使い方  
スタジオモードでF10ボタンを押すとUIが表示されます。  
  
スタジオモードの「キャラクター選択」で選択しているメイドの眼球を制御できます。  
キャラクター選択でメイドを切り替えると対象も自動的に変更されます。  
  
  
  
  
UI上の「有効にする」ボタンを押すと項目が表示されます。  
その場合、スタジオモードの「表情」の視線設定「視線追従」「カメラへ顔を向ける」が無効になります（両方ともチェックが外れる）  
もしくは両方のチェックを外すと自動的に項目が表示されます。  
  
・上下移動  
眼球を上下に移動させます。  
  
・左右移動  
眼球を左右に移動させます。  
「内や外にむかうようにする」にチェックが入っている場合はいわゆる寄り目にできます。  
  
・縮小  
眼球を縮小させます。  
  
  
  
  
「視線追従」「カメラへ顔を向ける」のどちらかにチェックが入った場合は無効になり、内容もリセットされます。  
  
  
呼び出しキーはConfig/EyeballControl.xml をテキストエディタで開き、  
<keyCode>F10</keyCode>  
の部分を任意のキー名を入力してください。  
範囲はF1 - F15の間です。存在しないキー名、それ以外のキーの場合はデフォルトのF10が使用されます。  
  
  
■ 利用規約  
MODはKISSサポート対象外です。  
MODを利用するに当たり、問題が発生してもKISSは一切の責任を負いかねます。  
カスタムオーダーメイド3D2を購入されている方のみが利用できます。  
カスタムオーダーメイド3D2上で表示する目的以外の利用は禁止します。  
これらの事項は http://kisskiss.tv/kiss/diary.php?no=558 を優先します。  
  
  
■ 何かあったら  
Twitter:@galleBlizzg に連絡ください