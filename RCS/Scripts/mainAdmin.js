$("#menu-toggle").click(function(e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});


$('.showItems').click(function() {
    var content = `<div id="product" class="container mt-5">
    <h2 class="container text-dark">Products: </h2>
    <hr>
    <table class=" table table-hover  table-dark">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Product Name</th>
                <th scope="col">Category</th>
                <th scope="col">Details</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">1</th>
                <td>Mark</td>
                <td>Otto</td>
                <td><button class="btn btn-outline-warning btn-sm text-white">Show Details</button></td>
            </tr>
            <tr>
                <th scope="row">2</th>
                <td>Jacob</td>
                <td>Thornton</td>
                <td><button class="btn btn-outline-warning btn-sm text-white">Show Details</button></td>
            </tr>
            <tr>
                <th scope="row">3</th>
                <td>Larry the Bird</td>
                <td>@twitter</td>
                <td><button class="btn btn-outline-warning btn-sm text-white">Show Details</button></td>
            </tr>
        </tbody>
    </table>
</div>`;
    $("#product").remove();
    $('#allClients').after(content);
})