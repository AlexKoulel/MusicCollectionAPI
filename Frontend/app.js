const apiURL = 'http://localhost:5000/albums';
const submitButton = document.getElementById("submit-button");
document.getElementById('albumForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    try
    {
        submitButton.disabled = true;
        const album = {
            title: document.getElementById('title').value,
            artist: document.getElementById('artist').value,
            genreId: parseInt(document.getElementById('genreId').value),
            releaseDate: document.getElementById('releaseDate').value,
            formatId: parseInt(document.getElementById('formatId').value),
        };
    
        await fetch(apiURL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(album)
        });
        loadAlbums();
        submitButton.disabled = false;
    }
    catch(error)
    {
        console.log(error);
        submitButton.disabled = false;
        alert("Something went wrong.\nMake sure the server is running and the URLs match.");
    }
});

async function loadAlbums() {
    const response = await fetch(`${apiURL}?page=1&pageSize=100`);
    const albums = await response.json();
    const albumsList = document.getElementById('albumsList');
    albumsList.innerHTML = '';

    albums.forEach(album => {
        const li = document.createElement('li');
        li.classList.add('list-group-item');
        li.textContent = `${album.title} by ${album.artist} - ${album.genre} - Released in ${album.releaseDate} - Owned in ${album.format}`;
        albumsList.appendChild(li);
    });
}

loadAlbums();