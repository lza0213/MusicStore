function GetUrl() {
    var Id = $('#item_Id').val();
    var imgString = '';
    var hrefString = '/MusicAlbum/Detail/';
    $ajax({
        type: 'POST',
        url: "/ShopingCart/GetUrl/" + Id,
        dataType: 'json',
        success: function (evt) {
            imgString+="<a href='"+hrefString+evt.Id+"'>"
            imgString+="<img src='/Pice/"+evt.UrlString+"'class=poster'alt="+evt.Name+"style='width:65px'/>";
            imgString += "</a>";
            $('#urllmage').html(imgString);
        }
    })
}