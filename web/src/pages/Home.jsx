import { useEffect, useState } from "react";
import Layout from "../components/layout/Layout";
import '../styles/Home.css';
import { fetchData, deleteData } from '../api/FetchAPI';
import { useNavigate } from "react-router-dom";
import { Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";

const Home = () => {
  const [personelData,setPersonelData] = useState([]);

  useEffect(() => {
        const fetchPersonelData = async () => {
            try {
                const url = 'http://localhost:63681/api/personel'; // Örnek bir API URL'i
                const data = await fetchData(url); // fetchData fonksiyonu ile veriyi alıyoruz
                setPersonelData(data); // Alınan veriyi state'e atıyoruz
            } catch (error) {
                console.error('Error fetching personnel data:', error);
            }
        };

        fetchPersonelData(); // useEffect içinde fetch işlemi yapmak için çağırıyoruz
  }, []);

  const navigate = useNavigate();

  const handleAddClick = () => {
    navigate("/create"); // 'create' sayfasına yönlendirme yapıyoruz
  };

  const handleDelete = async (id) => {
    try {
        const url = 'http://localhost:63681/api/personel'; // Sample API URL
        await deleteData(id, url); // Call deleteData function to delete the data
        // Update state after successful deletion to reflect changes
        setPersonelData(personelData.filter(item => item.id !== id));
        navigate("/");
    } catch (error) {
        console.error('Error deleting personnel data:', error);
    }
  };

    return (
        <Layout>
            <div className="homeContainer">
                <div className="tableContainer">
                    <Button variant="contained" color="success" onClick={handleAddClick}> Add +</Button>
                    <TableContainer >
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>ID</TableCell>
            <TableCell align="right">NAME</TableCell>
            <TableCell align="right">LASTNAME</TableCell>
            <TableCell align="right">IDENTİTY</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {personelData.map((row) => (
            <TableRow
              key={row.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.id}
              </TableCell>
              <TableCell align="right">{row.name}</TableCell>
              <TableCell align="right">{row.lastName}</TableCell>
              <TableCell align="right">{row.identityNo}</TableCell>
              <TableCell>
              <Button variant="contained" color="info"> INFO </Button>
              <Button variant="contained" color="warning"> UPDATE </Button>
              <Button variant="contained" color="error" onClick={() => handleDelete(row.id)}> DELETE -</Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>

                </div>
            </div>
        </Layout>
    );
}
export default Home;
