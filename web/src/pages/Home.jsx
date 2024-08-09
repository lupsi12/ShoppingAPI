import { useEffect, useState } from "react";
import Layout from "../components/layout/Layout";
import '../styles/Home.css';
import { fetchData, deleteData } from '../api/FetchAPI';
import { useNavigate } from "react-router-dom";
import { Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";

const Home = () => {
    return(
        <Layout>
            <div className="home-main">
                <div className="home-left">
                    buyuk alan
                </div>
                <div className="home-right">
                    <div className="home-up">
                        ust
                    </div>
                    <div className="home-down">
                        alt
                    </div>
                </div>
            </div>
        </Layout>
    );
}
export default Home;
