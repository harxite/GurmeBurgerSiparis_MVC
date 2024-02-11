function SearchItems() {
    $(document).ready(function () {
        $('#searchButton').click(function () {
            var searchTerm = $('#searchInput').val().toLowerCase();

            // Log the search term to the console
            console.log('Search Term: ' + searchTerm);

            // Hide or show cards based on the case-insensitive search term
            $('.card').each(function () {
                var cardSearchTerm = $(this).data('search');
                console.log('Card Search Term: ' + cardSearchTerm);
                if (cardSearchTerm && cardSearchTerm.includes(searchTerm)) {
                    $(this).show();
                } else {
                    $(this).hide();
                }
            });
        });
    });
}

function updateCurrentImage(input) {
    var reader = new FileReader();

    reader.onload = function (e) {
        document.getElementById('currentImage').src = e.target.result;
    };

    reader.readAsDataURL(input.files[0]);
}