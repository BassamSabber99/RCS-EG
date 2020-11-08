function Generate(e) {
    e.preventDefault();
    var ele = ` <div class="row justify-content-center mt-2">
                    <input type="file" id="images" name="ImageFile" required>
                    <button class="del btn btn-primary btn-sm float-right" onclick="Delete(event)" role="button">X</button>
                </div>`;
    $('#InputImage').append(ele)
}

function Delete(e) {
    e.preventDefault();
    obj.ImageFile.pop();
    $('.del:eq(0)').parent('div').remove();
}

$(document).ready(function() {
    $('.popover-dismiss').popover({
        trigger: 'focus'
    })

    $('.chat').on("click", function() {
        $('.inbox').slideToggle(500);
    })

})