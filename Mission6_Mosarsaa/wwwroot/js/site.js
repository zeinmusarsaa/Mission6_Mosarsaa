// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// JavaScript for handling movie editing

$("#addMovieForm").submit(function (event) {
    event.preventDefault();
    var formData = $(this).serialize();
    var movieId = $('#movieId').val();
    var url = movieId == 0 ? '/movies/AddMovie' : '/movies/Edit/' + movieId;

    $.ajax({
        url: url,
        type: 'POST',
        data: formData,
        success: function (response) {
            // ... (existing success handling code)
        },
        error: function () {
            alert("An error occurred");
        }
    });
});


function editMovie(movieId, title, categoryId, year, director, rating, edited, copiedToPlex, lentTo, notes) {
    // Populate the form with the movie's data
    $('#categoryId').val(categoryId);
    $('#title').val(title);
    $('#year').val(year);
    $('#director').val(director);
    $('#rating').val(rating);
    $('#edited').prop('checked', edited);
    $('#copiedToPlex').prop('checked', copiedToPlex);
    $('#lentTo').val(lentTo);
    $('#notes').val(notes);
    $('#movieId').val(movieId);

    // Change the form action and submit button for editing
    $('#addMovieForm').attr('action', '/movies/Edit/' + movieId);
    $('#addMovieForm button[type="submit"]').text('Update Movie');
}


function deleteMovie(movieId) {
    if (confirm("Are you sure you want to delete this movie?")) {
        $.ajax({
            url: "/movies/Delete/" + movieId,
            type: "POST",
            success: function () {
                // Remove the corresponding movie row from the table
                $("tr").filter(function () {
                    return $(this).find('a').attr('onclick').includes('deleteMovie(' + movieId + ')');
                }).remove();
            },
            error: function () {
                alert("Error deleting movie");
            }
        });
    }
}


