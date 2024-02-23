$(document).ready(function () {

    // Function to handle adding a new movie
    function addMovie() {
        var formData = $('#addMovieForm').serialize();
        formData = formData.replace(/Edited=on/g, 'Edited=true');
        formData = formData.replace(/CopiedToPlex=on/g, 'CopiedToPlex=true');

        // Add false for unchecked checkboxes
        if (!formData.includes('Edited=')) {
            formData += '&Edited=false';
        }
        if (!formData.includes('CopiedToPlex=')) {
            formData += '&CopiedToPlex=false';
        }

        $.ajax({
            url: '/movies/AddMovie',
            type: 'POST',
            data: formData,
            success: function (response) {
                // Assuming response contains the details of the new movie
                var newRow = '<tr id="movie-' + response.movieId + '">'
                    + '<td>' + response.title + '</td>'
                    + '<td>' + response.categoryName + '</td>'
                    + '<td>' + response.year + '</td>'
                    + '<td>' + response.director + '</td>'
                    + '<td>' + response.rating + '</td>'
                    + '<td>' + (response.edited ? 'Yes' : 'No') + '</td>'
                    + '<td>' + (response.copiedToPlex ? 'Yes' : 'No') + '</td>'
                    + '<td>' + (response.lentTo || 'N/A') + '</td>'
                    + '<td>' + (response.notes || 'N/A') + '</td>'
                    + '</tr>';
                $('table tbody').append(newRow);
                location.reload(); 
            },
            error: function () {
                alert("Error adding movie");
            }
        });
    }

    // Function to handle updating an existing movie
    function updateMovie(movieId) {
        var formData = $('#addMovieForm').serialize();
        console.log(formData); 

        formData = formData.replace(/Edited=on/g, 'Edited=true');
        formData = formData.replace(/CopiedToPlex=on/g, 'CopiedToPlex=true');

        // Add false for unchecked checkboxes
        if (!formData.includes('Edited=')) {
            formData += '&Edited=false';
        }
        if (!formData.includes('CopiedToPlex=')) {
            formData += '&CopiedToPlex=false';
        }

        $.ajax({
            url: '/movies/Edit/' + movieId,
            type: 'POST',
            data: formData,
            success: function (response) {
                console.log(response);
                var row = $('#movie-' + movieId);
                row.find('td').eq(0).text(response.title);
                row.find('td').eq(1).text(response.categoryName);
                row.find('td').eq(2).text(response.year);
                row.find('td').eq(3).text(response.director);
                row.find('td').eq(4).text(response.rating);
                row.find('td').eq(5).text(response.edited ? 'Yes' : 'No');
                row.find('td').eq(6).text(response.copiedToPlex ? 'Yes' : 'No');
                row.find('td').eq(7).text(response.lentTo || 'N/A');
                row.find('td').eq(8).text(response.notes || 'N/A');
                location.reload();
            },
            error: function () {
                alert("Error updating movie");
            }
        });
    }

    // Event listener for form submission
    $("#addMovieForm").submit(function (event) {
        event.preventDefault();
        var movieId = $('#movieId').val();

        if (movieId == 0) {
            addMovie();
        } else {
            updateMovie(movieId);
        }
 
    });

    // Function to populate the form for editing
    window.editMovie = function (movieId, title, categoryId, year, director, rating, edited, copiedToPlex, lentTo, notes) {
        $('#movieId').val(movieId);
        $('#categoryId').val(categoryId);
        $('#title').val(title);
        $('#year').val(year);
        $('#director').val(director);
        $('#rating').val(rating);
        $('#edited').prop('checked', edited);
        $('#copiedToPlex').prop('checked', copiedToPlex);
        $('#lentTo').val(lentTo);
        $('#notes').val(notes);

        // Change the form submit button text for editing
        $('#addMovieForm button[type="submit"]').text('Update Movie');
    };

    // Function to handle movie deletion
    window.deleteMovie = function (movieId) {
        if (confirm("Are you sure you want to delete this movie?")) {
            $.ajax({
                url: "/movies/Delete/" + movieId,
                type: "POST",
                success: function () {
                    $('#movie-' + movieId).remove();
                    location.reload();
                },
                error: function () {
                    alert("Error deleting movie");
                }
            });
        }
    }
});


