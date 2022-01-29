# MemoEngine
### ログインしなず、掲示物を作成可な能掲示板。
![MemoEngine-Index](https://user-images.githubusercontent.com/77004633/150374473-64bcd07c-b2b9-4404-852f-3a2ede38f8ce.png)


---------------------------
## ０．MemoEngineとは
> 誰でもログインさせず、簡単に作成できるウェブサイトである。<br />
> 主な機能では掲示物作成、訂正、削除、ファイルアップロード、コメント付き、返事付きがある。<br/>
> 

----------------------------
## １．１　作成（ Create )
> １．１．１　掲示物作成
> ![MemoEngine-Write](https://user-images.githubusercontent.com/77004633/150375508-95a27f17-6a61-4296-aabb-d5530d7f7620.png)<br />
> 赤いアスタリスクは必ず記入するもので、付けていない項目は空欄でも構わない。<br />
> 作成の時、マクロ悪用ができないように特殊文字列を入力するように構成した。<br />
> ファイルアップロードは最大３０MBまでアップロードできる。<br />
> TEXT,HTML,MIXEDで三つのエンコーディング方式がある。<br/>
> TEXTはそのままの内容を表示し、MIXEDは改行処理した内容を表示し、HTMLはHTMLテグを認識し表示する。<br />
> 掲示物の内容の場合、今の状態でもHTMLタグを認識できるがその方式の不親切がありWYSIWYGに変更する予定だ。<br />
> アップロードしたファイルがある場合、初期画面にその種類によって異なるアイコンで表示される。<br /><br />

> １．１．２　コメント作成
> 
> ![MemoEngine-ComentWrite](https://user-images.githubusercontent.com/77004633/150623862-e4be4db0-1353-41eb-aa72-305bd6979ac0.png)<br />
> 掲示物閲覧状態で作成できる項目。更新はできない。<br />
> パスワードはコメント除外の時、使用される。

> １．１．３　返事作成
> ![MemoEngine-ReplyWrite](https://user-images.githubusercontent.com/77004633/150685581-4d5f1bb1-a684-4ec8-b6ec-85e761289c66.png)<br />
> 掲示物閲覧画面から返事作成項目を選択し、掲示物に対する返事を作成可能。<br />
> 返事に対する返事も作成可能。<br />
> 掲示物作成と同じく作成の旅には必要項目を記入しない場合は作成不可能。<br />
> 元の掲示物を親として、返事の返事は元の返事が親になる。
> 

> 
<hr />

## １．２　閲覧　（ Read )
> １．２．１　掲示物閲覧
> ![MemoEngine-Read](https://user-images.githubusercontent.com/77004633/150454540-7f07e979-2084-4fba-97a3-ddea5df15a45.png)<br />
> こちらからコメントや本文を読める。<br />
> コメントの場合はこの画面から追加、除外することができる。<br />
> 本文の修訂、削除、更新はこの画面からできる。

<hr />

## １．３　更新　（　Update　）
> １．３．１　掲示物更新
![MemoEngine-Update](https://user-images.githubusercontent.com/77004633/150685523-96742806-b3ed-4b87-baef-69165fe3dd42.png)<br />
> 作成した掲示物や返事を修正する。修正するには作成時のパスワードがあわさない場合、修正はできない。

<hr />

## １．４　削除　（　Delete　）
> １．４．１　掲示物除外
![MemoEngine-Delete](https://user-images.githubusercontent.com/77004633/150685553-12f634ef-8020-474a-8e77-bfcce0c35c09.png)<br />

> １．４．２　コメント除外
![MemoEngine-ComentDelete](https://user-images.githubusercontent.com/77004633/150685540-439cc57d-4432-4f04-84a2-3bd1cd896d36.png)

> 各項目（掲示物、コメント）の削除には該当項目を作成するときのパスワードが必要だ。<br />
> 間違うパスワード入力すれば、削除は進まなく、この画面に警告文が出力される。

<hr />

> ## ２．バージョン一覧<br />
> DotNetFramework 4.6　<br />
> Bootstrap 3.4.1<br />
> JQuery 3.4.1<br />
> MSSQL 16.100.46521
