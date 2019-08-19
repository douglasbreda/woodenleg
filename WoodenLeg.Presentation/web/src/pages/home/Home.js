import React from "react";
import NavBar from "../../components/navbar";
import Footer from "../../components/footer";
import Recent from "../../components/announces";

export default function Home() {
  return (
    <>
      <NavBar />
      <Recent />
      <Footer />
    </>
  );
}
