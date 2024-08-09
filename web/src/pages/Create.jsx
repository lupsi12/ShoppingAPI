import { Button, Input, Stack, TextField } from "@mui/material";
import { useState } from "react";
import Layout from "../components/layout/Layout";
import { createPost } from '../api/FetchAPI' // createPost fonksiyonunu import ediyoruz
import '../styles/Create.css';
import { useNavigate } from "react-router-dom";


const Create = () => {
    const [selectedDate, setSelectedDate] = useState('');
    const [formData, setFormData] = useState({
        name: '',
        lastName: '',
        identityNo: '',
        email: '',
        password: '',
    });

    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        
        const updatedFormData = { ...formData, date: selectedDate };

        try {
            const url = 'http://localhost:5250/api/personel'; // POST işlemi yapılacak API URL'i
            const responseData = await createPost(updatedFormData, url); // createPost fonksiyonunu kullanarak POST işlemi yapılıyor
            
            // POST işlemi başarılı olduğunda yapılabilecek işlemler
            alert('Successfully created: ' + JSON.stringify(responseData));
            
            // Örneğin, formu sıfırlama veya başka bir işlem yapma

             // Yönlendirme işlemi
             navigate('/');
            
        } catch (error) {
            console.error('Error occurred while creating post:', error);
            alert('Error occurred, please try again later.');
        }
    };

    const handleChange = (event) => {
        const { name, value } = event.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };

    return (
        <Layout>
            <div className="createContainer">
                <div className="inputContainer">
                    <h2>CREATE PERSONEL</h2>
                    <form onSubmit={handleSubmit}>
                        <Stack spacing={3}>
                            <Input
                                name="name"
                                placeholder="NAME"
                                color="success"
                                required
                                value={formData.name}
                                onChange={handleChange}
                            />
                            <Input
                                name="lastName"
                                placeholder="LAST NAME"
                                color="success"
                                required
                                value={formData.lastName}
                                onChange={handleChange}
                            />
                            <Input
                                name="identityNo"
                                placeholder="IDENTITY NO"
                                color="success"
                                required
                                value={formData.identityNo}
                                onChange={handleChange}
                            />
                            <Input
                                name="email"
                                placeholder="EMAIL"
                                color="success"
                                required
                                value={formData.email}
                                onChange={handleChange}
                            />
                            <Input
                                name="password"
                                type="password"
                                placeholder="PASSWORD"
                                color="success"
                                required
                                value={formData.password}
                                onChange={handleChange}
                            />
                            <TextField
                                label="Select Date"
                                type="date"
                                name="selectedDate"
                                value={selectedDate}
                                onChange={(e) => setSelectedDate(e.target.value)}
                                InputLabelProps={{
                                    shrink: true,
                                }}
                                required
                            />
                            <Button variant="contained" color="success" type="submit">
                                CREATE
                            </Button>
                        </Stack>
                    </form>
                </div>
            </div>
        </Layout>
    );
};

export default Create;
