// GET işlemi için fetchData fonksiyonu
export const fetchData = async (url) => {
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error;
    }
};

// DELETE işlemi için deleteData fonksiyonu
export const deleteData = async (id, url) => {
    try {
        const response = await fetch(`${url}/${id}`, {
            method: 'DELETE'
        });
        
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        // Since DELETE typically does not return content, we can just return a success message or similar
        return { success: true, message: 'Resource deleted successfully' };
        
    } catch (error) {
        console.error('Error deleting data:', error);
        throw error;
    }
};


// POST işlemi için createPost fonksiyonu
export const createPost = async (data, url) => {
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return await response.json();
    } catch (error) {
        console.error('Error creating post:', error);
        throw error;
    }
};

// PATCH işlemi için updatePost fonksiyonu
export const updatePost = async (id, updatedData, url) => {
    try {
        const response = await fetch(`${url}/${id}`, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(updatedData),
        });
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return await response.json();
    } catch (error) {
        console.error('Error updating post:', error);
        throw error;
    }
};
