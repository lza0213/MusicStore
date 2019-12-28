$(document).ready(
    function PreLoading() {
        getPicUrlString();
        getAlbums();
        
    }
    );

//轮播图片读库实现
function getPicUrlString() {
    $.ajax({
        type: 'POST',
        async: true,
        url: "/MusicAlbum/GetPics",
        dataType: "json",
        success: function (data) {
            var divContent = '';
            $.each(
                data,
                function (item) {
                    //alert(item);
                    //alert(data[item]);
                    if (item == 0) {
                        divContent+="<div class='item active'>";
                        divContent += "<img src='../PICS/"+ data[item]+ "'style='width:100%' />";
                        divContent+="</div>";
                    }
                    else{
                        divContent+="<div class='item'>";
                        divContent += "<img src='../PICS/" + data[item] + "'style='width:100%' />";
                        divContent+="</div>";
                    }
                }) ;
            divContent="<div class='carousel-inner' role='listbox'>"+divContent+"</div>";
            $("#carousel").html(divContent);
        }
    })
}

//轮播列表实现
function getAlbums() {
    $.ajax({
        
        type: 'POST',
        async: true,
        url: "/MusicAlbum/GetMusicStoreAlbums",
        dataType: 'json',
        success: function (data) {
            var divContent = '';//回传的HTML字符组装
            var divContent1 = '';//第一列表HTML字符组装
            var divContent2 = '';//第二列表HTML字符组装
            var hrefString = '/MusicAlbum/Detail/';
            var count=0;
            divContent+="<div class='carousel-inner' role='listbox'>";

            divContent1+="<div class='item active'>";
            divContent1 += "<div class='row'>";
            divContent2 += "<div class='item'>";
            divContent2 += "<div class='row'>";
            $.each(
                data,
                function (item) {
                    if (count < 6) {
                        divContent1 += "<div class='col-md-2'>";
                        divContent1 += "<div class='thumbnail'>";
                        divContent1+="<a href='"+hrefString+data[item].ID+"'>";
                        divContent1 += "<img src='../PICS/" + data[item].Urlstring + "' class='img-responsive' />";
                        divContent1+="</a>"
                        divContent1 += "</div></div>";
                        count += 1;
                    }
                    else {
                        divContent2 += "<div class='col-md-2'>";
                        divContent2 += "<div class='thumbnail'>";
                        divContent2+= "<a href='" + hrefString +data[item].ID+ "'>";
                        divContent2 += "<img src='../PICS/" + data[item].Urlstring + "' class='img-responsive' />";
                        divContent2 += "</a>"
                        divContent2 += "</div></div>";
                    }
                });
            divContent1 += "</div></div>";
            divContent2 += "</div></div>";
            divContent += divContent1 + divContent2 + "</div>"
            $("#carousel-list").html(divContent);
        }
    })
}

$('table tbody').on('click','tr',function(){
    //alert("点赞成功");
    var ID = $('#item_ID').val();
    $.ajax({
        type: "post",
        async: true,
        dataType: "text",
        data: { "id": ID },//url方法调用的参数传值，引号内容是方法形参，后面传初值
        url: "/MusicAlbum/AddCTR",
        dataType: 'json'
        
    });
});

//function AddCTR() {
//    window.alert("点赞成功");
//}
