//識別上傳的是不是圖檔
function checkInputType(input) {
    var type = /[^.]+$/.exec(input)[0];
    if (type == 'png' || type == 'gif' || type == 'jpeg' || type == 'jpg' || type == 'PNG' || type == 'JPEG' || type == 'GIF' || type == 'JPG') {
        //pass
    } else {
        alert('不支援的檔案格式！請選擇 image 檔案。');
        $("#image").val("");
    }
}
//圖片預覽大小
$('.pre_img').css('height', 200);
//圖片預覽
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("#preview_img").attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
        checkInputType(input.files[0].name);
    };
}
$("#image").change(function () {
    readURL(this);
});

//new Date(); 輸入now或是yyyy-MM-dd，輸出標準時間格式
//$('#id').val() 輸出yyyy-MM-dd
//日期加減，輸入(Date()日期格式,加減天數)，輸出Date()日期格式
function GetDate(date, addDays) {
    var getDate = date.setDate(date.getDate() + addDays);//加完後會轉碼
    getDate = new Date(getDate);//再轉回標準時間
    return getDate;
}
//輸入(Date()日期格式，輸出(yyyy-MM-dd)
function GetDateOutput(date) {
    var day = ("0" + date.getDate()).slice(-2);//格式化日，如果小於9，前面補0
    var month = ("0" + (date.getMonth() + 1)).slice(-2);//格式化月，如果小於9，前面補0
    var Date = date.getFullYear() + "-" + (month) + "-" + (day);//拼裝完整日期格式
    return Date;
}
//日期範圍浮動(輸入yyyy-MM-dd)
function DateRange() {
    // 取得標準時間  Date()設定預設值now
    var now = new Date();
    //預設起始日期+1天，並設定最小值
    var startDateStart = GetDate(now, 0);
    var adStartDateStart = GetDateOutput(startDateStart);
    $('#cADStartDate').val(adStartDateStart);
    $('#cADStartDate').attr('min', adStartDateStart);
    //設定最大值+53
    var startDateEnd = GetDate(startDateStart, 53);
    var adStartDateEnd = GetDateOutput(startDateEnd);
    $('#cADStartDate').attr('max', adStartDateEnd);

    var now2 = new Date();
    //預設結束日期開始+7天
    var enddatestart = GetDate(now2, 6);
    var adenddatestart = GetDateOutput(enddatestart);
    $('#cADDueDate').val(adenddatestart);
    $('#cADDueDate').attr('min', adenddatestart);
    //結束+30天
    var enddateend = GetDate(enddatestart, 53);
    var adenddateend = GetDateOutput(enddateend);
    $('#cADDueDate').attr('max', adenddateend);
};
DateRange();
//日期浮動1
$('#cADStartDate').change(function () {
    var firstDay = $('#cADStartDate').val();
    var lastDay = $('#cADDueDate').val();
    var allDayCount = DateDiff(firstDay, lastDay);
    var d = new Date(firstDay);
    var dd = GetDate(d, 6);
    var ddd = GetDateOutput(dd);
    if (firstDay < lastDay) {
        if (allDayCount < 6) {
            $('#cADDueDate').val(ddd);
        }
    } else {
        $('#cADDueDate').val(ddd);
    };
    actionDateCheck();
})
//日期浮動2
$('#cADDueDate').change(function () {
    var firstDay = $('#cADStartDate').val();
    var lastDay = $('#cADDueDate').val();
    var allDayCount = DateDiff(firstDay, lastDay);
    var d = new Date(lastDay);
    var dd = GetDate(d, -6);
    var ddd = GetDateOutput(dd);
    if (firstDay < lastDay) {
        if (allDayCount < 7) {
            $('#cADStartDate').val(ddd);
        }
    } else {
        $('#cADStartDate').val(ddd);
    };
    actionDateCheck();
})
//日期確認顯示
function actionDateCheck() {
    var fullDaysArray = outPutStr();
    var fullDays = ArrayTransToStr(fullDaysArray);
    console.log(fullDays);
    if (fullDays == "") {
        $('#fullDays').text("");
    } else {
        $('#fullDays').text("以下日期" + fullDays + "已滿，將不會為您放上廣告");
    }
}
actionDateCheck();
//日期變色，做不出來..... 



//選擇的日期字串
var selectString = "";
//日期天數差公式，先算出天數差才知道要取多少字串
function DateDiff(sDate1, sDate2) { // 輸入$('#cADStartDate').val()yyyy-MM-dd
    var oDate1 = new Date(sDate1);
    var oDate2 = new Date(sDate2);
    var iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24); // 把相差的毫秒數轉換為天數
    return iDays;
};
//選擇的日期轉字串
function SelectDays() {
    selectString = "";
    var firstDay = $('#cADStartDate').val();
    var lastDay = $('#cADDueDate').val();
    var allDayCount = DateDiff(firstDay, lastDay);
    for (i = 0; i < allDayCount + 1; i++) {
        selectString += firstDay;
        selectString += ",";
        firstDay = new Date(firstDay);
        GetDate(firstDay, 1);
        firstDay = GetDateOutput(firstDay);
    }
    selectString = selectString.substring(0, selectString.length - 1);
    return selectString;
}
//字串轉陣列
function StrTransToArray(string) {
    return (string.split(','));
}
//兩陣列取出重複值
function GetRepeat(array1, array2) {
    var result = array1.filter(function (val) {
        return array2.indexOf(val) != -1;
    });
    return result;
}
//陣列A-陣列B，回傳新的陣列A(選擇的字串刪掉重複的)
function arrChange(arrayA, arratB) {
    for (var i = 0; i < arratB.length; i++) {
        for (var j = 0; j < arrayA.length; j++) {
            if (arrayA[j] == arratB[i]) {
                arrayA.splice(j, 1);
                j = j - 1;
            }
        }
    }
    return arrayA;
}
//陣列轉字串
function ArrayTransToStr(array) {
    return (array.join(','));
}
//最終輸出
function outPutStr() {
    SelectDays();
    var getString = $('#getActionDate').val();//取得已滿日期字串
    var getStringtoArr = StrTransToArray(getString);//取得的已滿日期陣列
    var selectStrArray = StrTransToArray(selectString);//get的已滿天數轉陣列
    var repeatStr = GetRepeat(getStringtoArr, selectStrArray);//取出重複的陣列
    var finalStrArray = arrChange(selectStrArray, repeatStr);//扣掉重複的陣列
    var c = finalStrArray.length;
    $('#ActionDateCount').val(c);//實際可用天數
    var finalStr = ArrayTransToStr(finalStrArray);

    $('#cADActionDate').val(finalStr);//最終陣列轉回字串後輸出

    return repeatStr;//回傳已滿天數
}

//送出前確認資料
//1.輸入是否為空
function CheckNotNull(val) {
    var str = val.replace(/(^\s*)|(\s*$)/g, '');//去除空格;
    if (str == '' || str == undefined || str == null) {
        console.log('空')
        return false;
    } else {
        console.log('非空');
        return true;
    };
};
function CheckAllNotNull() {
    var checkFirmSN = $('#cFirmSN').val();
    var checkStartDate = $('#cADStartDate').val();
    var checkDueDate = $('#cADDueDate').val();
    var checkimage = $('#image').val();
    var checkADURL = $('#cADURL').val();

    //未填寫框變色
    if (!CheckNotNull(checkFirmSN)) {
        $('#FirmSN').attr('style', 'color:red')
    } else {
        $('#FirmSN').removeAttr('style')
    }
    if (!CheckNotNull(checkStartDate)) {
        $('#StartDate').attr('style', 'color:red')
    } else {
        $('#StartDate').removeAttr('style')
    }
    if (!CheckNotNull(checkDueDate)) {
        $('#DueDate').attr('style', 'color:red')
    } else {
        $('#DueDate').removeAttr('style')
    }
    if (!CheckNotNull(checkimage)) {
        $('#lblImage').attr('style', 'color:red')
        $('#lblImage').text("未選擇圖檔")
    } else {
        $('#lblImage').removeAttr('style')
        $('#lblImage').text("選擇1個圖檔")
    }
    if (!CheckNotNull(checkADURL)) {
        $('#URL').attr('style', 'color:red')
    } else {
        $('#URL').removeAttr('style')
    }

    if (CheckNotNull(checkFirmSN)
        && CheckNotNull(checkStartDate)
        && CheckNotNull(checkDueDate)
        && CheckNotNull(checkimage)
    ) {
        if (!CheckNotNull(checkADURL)) {
            if (!confirm("未填寫URL，是否繼續?")) {
                return false;
            };
        };
        return true;
    } else {
        alert("資料未齊全，上傳失敗");
        return false;
    };
}
//2.確認日期時間
//上方用MIN MAX限制
//3.送出
function CheckUpLoad() {
    if (CheckAllNotNull()) {
        if (confirm("確認資料填寫正確") == true) {
            return true
            alert("上傳成功");
        } else {
            return false;
        };
    } else {
        return false;
    }
}

//網頁30分鐘重載
setInterval("resetPage();", 30 * 60 * 1000);
function resetPage() {
    history.go(0);
    alert("超時重新載入");
};