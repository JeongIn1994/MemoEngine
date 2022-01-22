# MemoEngine
### ログインしなず、掲示物を作成可な能掲示板。
![MemoEngine-Index](https://user-images.githubusercontent.com/77004633/150374473-64bcd07c-b2b9-4404-852f-3a2ede38f8ce.png)


---------------------------
## ０．MemoEngineとは
> 誰でもログインしなず、簡単に作成できるウェブサイトである。<br />
> 主な機能では掲示物作成、訂正、削除、ファイルアップロード、コメント付き、返事付きがある。<br/>
> 
> <b>バージョン一覧</b><br />
> DotNetFramework 4.6　<br />
> Bootstrap 3.4.1<br />
> JQuery 3.4.1<br />
> MSSQL
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
> ![MemoEngine-ComentWrite](https://user-images.githubusercontent.com/77004633/150623862-e4be4db0-1353-41eb-aa72-305bd6979ac0.png)<br />
> 掲示物閲覧状態で作成できる項目。更新はできない。

> 
<hr />
## １．２　閲覧　（ Read )
> ![MemoEngine-Read](https://user-images.githubusercontent.com/77004633/150454540-7f07e979-2084-4fba-97a3-ddea5df15a45.png)

<hr />
## １．３　更新　（　Update　）

<hr />
## １．４　削除　（　Delete　）
<hr />
