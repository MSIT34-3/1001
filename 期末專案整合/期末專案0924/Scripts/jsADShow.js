//動態增加ImgLi
//function AddImgLi(adNum, adName, adURL) {
//    //直接指定ul
//    var ul = document.getElementById("slideImg");

//    //新增img
//    var img = document.createElement("img");
//    //設定屬性
//    img.setAttribute("alt", adNum);
//    img.setAttribute("src", "~/ADImage/" + adName);

//    //新增a然後把img放進去
//    var a = document.createElement("a");
//    a.href = adURL;
//    a.appendChild(img);

//    //新增 li然後把a放進去
//    var li = document.createElement("li");
//    li.appendChild(a);

//    //最後把li裝進ul
//    ul.appendChild(li);
//}
////動態增加PageLi
//function AddPageLi() {
//    //直接指定ul
//    var ul = document.getElementById("pages");
//    var li = document.createElement("li");
//    ul.appendChild(li);
//}
//viewbag放不進來QQ
//只能直接寫進BODY

$(function () {
    //1.第一張圖
    //2.多張圖
    //3.換頁清單
    //4.第一張圖移動
    //5.N張移動 INDEX()讀取索引值
    //6.換頁變色
    //7.左右換頁
    let slideIndex = 0;
    let slideMove = 0;
    //點點填滿
    $('#pages li').eq(0).css('background', 'white')
    //移動到點點上換張
    $('#pages li').on('mouseenter', function () {
        slideIndex = $(this).index()
        moveImg();
    })
    let slideCount = $('#slideImg li').length
    $('#slideNext').on('click', function () {
        slideIndex++;
        if (slideIndex >= slideCount) {
            slideIndex = 0
        }
        moveImg();
    })
    $('#slideBefore').on('click', function () {
        slideIndex--;
        if (slideIndex < 0) {
            slideIndex = slideCount - 1
        }
        moveImg();

    })
    function moveImg() {
        slideMove = 0 - slideIndex * 800;
        $('#slideImg').css('left', slideMove)
        $('#pages li').eq(slideIndex).css('background', 'white').siblings().css('background', 'transparent')
    }
    //自動換張
    setInterval(autoImg, 5000)
    function autoImg() {
        slideIndex++;
        if (slideIndex >= slideCount) {
            slideIndex = 0
        }
        moveImg();
    }
})