// https://mementoo.info/archives/1617
var grayFilter = function(src, dst, width, height) {
    for (var i = 0; i < height; i++) {
        for (var j = 0; j < width; j++) {
            var idx = (j + i * width) * 4;
            var gray = parseInt(((src[idx] + src[idx + 1] + src[idx + 2]) / 3) / 64) * 64;
            if (i % 20 == 0 && j % 20 == 0) {
              console.log(gray);
            }
            dst[idx] = gray;
            dst[idx + 1] = gray;
            dst[idx + 2] = gray;
            dst[idx + 3] = src[idx + 3];
        }
    }
};
var sobelFilter = function(src, dst, width, height) {
    var weight = [
        -1,0,1,
        -2,0,2,
        -1,0,1
    ];
    for (var i = 0; i < height; i++) {
        for (var j = 0; j < width; j++) {
            var idx = (j + i * width) * 4;
            var val = [0,0,0];
            for(var k = -1; k <= 1; k++){
                for(var l = -1; l <= 1 ; l++){
                    var x = j + l;
                    var y = i + k;
                    if(x < 0 || x >= width || y < 0 || y >= height){
                        continue;
                    }
                    var idx1 = (x + y * width) * 4;
                    var idx2 = (l + 1) + (k + 1)*3;
                    val[0] += weight[idx2]*src[idx1];
                    val[1] += weight[idx2]*src[idx1 + 1];
                    val[2] += weight[idx2]*src[idx1 + 2];
                }
            }
            dst[idx] = val[0];
            dst[idx + 1] = val[1];
            dst[idx + 2] = val[2];
            dst[idx + 3] = src[idx + 3];
        }
    }
};
window.addEventListener("DOMContentLoaded", function(){
    //ファイルオープンの際のイベント
    var ofd = document.getElementById("selectfile");
    ofd.addEventListener("change", function(evt) {
        var img = null;
        var canvas = document.createElement("canvas");
        //var canvas = document.getElementById('canvas');
 
        var file = evt.target.files;
        var reader = new FileReader();
 
        //dataURL形式でファイルを読み込む
        reader.readAsDataURL(file[0]);
 
        console.log('enter');
        //ファイルの読込が終了した時の処理
        reader.onload = function(){
            img = new Image();
            img.onload = function(){
                //キャンバスに画像をセット
                var context = canvas.getContext('2d');
                var width = img.width;
                var height = img.height;
                canvas.width = width;
                canvas.height = height;
                context.drawImage(img, 0, 0);
 
                //フィルター処理
                var srcData = context.getImageData(0, 0, width, height);
                var dstData = context.createImageData(width, height);
                var src = srcData.data;
                var dst = dstData.data;
                //grayFilter(src, dst, width, height);
                grayFilter(src, dst, width, height);
                context.putImageData(dstData, 0, 0);
 
                //画像タグに代入して表示
                var dataurl = canvas.toDataURL();
                document.getElementById("output").innerHTML = "<img src='" + dataurl + "'>";
            }
            img.src = reader.result;
        }
    }, false);
});
