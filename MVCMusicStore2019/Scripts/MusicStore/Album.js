$(document).ready(
    function Preloading() {
        loadGenre();
        loadArtist();
        loadAlbumType();

    });
//流派下拉菜单实现
//select的使用技巧：https://www.w3cschool.cn/htmltages/tag-select.html
function loadGenre() {
    var Genre = document.getElementById("CurrentGenreSelectedID").value;
    $.ajax({
        type: 'POST',
        async: true,
        url: '/AdminAlbum/GetGenreList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            var contentString = "";
            var object = data;
            //selectionID = $('#CurrentGenreSelectedID').val();
            //alert(selectionID);
            $.each(object, function (item) {
                if (object[item].ID == Genre)
                {
                    contentString += "<option value='" + object[item].ID + "' selected>" + object[item].Name + "</option>"
                }
                else {
                    contentString += "<option value='" + object[item].ID + "'>" + object[item].Name + "</option>";
                }    
                });
            contentString = "<select id='GenreID' name='GenreID' class='form-control'>" + contentString + "</select>";
            $('#GenreSelectList').html(contentString);
            $('#GenreSelectList').val($('CurrentGenreSelectedID').val());//被选项
        }
    })
}
function loadArtist() {
    var Artist = document.getElementById("CurrentArtistSelectedID").value;
    $.ajax({
        type: 'POST',
        async: true,
        url: '/AdminAlbum/GetArtistList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            var contentString = "";
            var object = data;
            $.each(object, function (item) {
                if (object[item].ID == Artist) {
                    contentString += "<option value='" + object[item].ID + "' selected>" + object[item].Name + "</option>"
                }
                else {
                    contentString += "<option value='" + object[item].ID + "'>" + object[item].Name + "</option>";
                }
            });
            contentString = "<select id='ArtistID' name='ArtistID' class='form-control'>" + contentString + "</select>";
            $('#ArtistSelectList').html(contentString);
            $('#ArtistSelectList').val($('CurrentArtistSelectedID').val());//被选项
        }
    })
}
function loadAlbumType() {
    var AlbumType = document.getElementById("CurrentAlbumTypeSelectedID").value;
    $.ajax({
        type: 'POST',
        async: true,
        url: '/AdminAlbum/GetAlbumTypeList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            var contentString = "";
            var object = data;
            $.each(object, function (item) {
                if (object[item].ID == AlbumType) {
                    contentString += "<option value='" + object[item].ID + "' selected>" + object[item].Name + "</option>"
                }
                else {
                    contentString += "<option value='" + object[item].ID + "'>" + object[item].Name + "</option>";
                }
            });
            contentString = "<select id='AlbumTypeID' name='AlbumTypeID' class='form-control'>" + contentString + "</select>";
            $('#AlbumTypeSelectList').html(contentString);
            $('#AlbumTypeSelectList').val($('CurrentAlbumTypeSelectedID').val());//被选项
        }
    })
}
function upFileImg() {
    var files = $('#UploadeFile').prop('files');
    var data = new FormData();
    data.append('imgFile', files[0]);
    $.ajax({
        type: 'POST',
        url: "/AdminAlbum/UploadImgFile",
        data: data,
        dataType: 'json',
        cache: false,
        processData: false,
        contentType: false,
        success: function (result) {
            alert(result.imgUrlString);
            $("#Urlstring").val(result.imgUrlString);
        }
    })
}
function singleFileSelected(evt) {
    var selectedFile = ($("#UploadeFile"))[0].files[0];
    if (selectedFile) {
        var FileSize = 0;
        var imgeType = /image.*/;
        if (selectedFile.size > 1048576) {
            FileSize = Math.round(selectedFile.size * 100 / 1048576) / 100 + "MB";
        }
        else if (selectedFile.size > 1024) {
            FileSize = Math.round(selectedFile.size * 100 / 1024) / 100 + "KB";
        }
        else {
            FileSize = selectedFile.size + "Bytes";
        }
        $("#FileName").text("文件名：" + selectedFile.name);
        $("#FileSize").text("大小：" + FileSize);
        $("#FileType").text("类型：" + selectedFile.type);
    }
    if (selectedFile.type.match(imgeType)) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("#Imgcontainer").empty();
            var dataURL = reader.result;
            var img = new Image();
            img.src = dataURL;
            img.className = "thumb";
            $("#Imgcontainer").append(img);
        };
        reader.readAsDataURL(selectedFile);
    }
}